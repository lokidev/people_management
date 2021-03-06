using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Repos;
using PeopleManagement.Messaging.Interfaces;
using Microsoft.Extensions.Configuration;
using PeopleManagement.Services.Interfaces;

namespace PeopleManagement.Services
{
    public class PeopleService : IPeopleService
    {
        private IRabbitMqService mRabbitMqService;
        private readonly IConfiguration _configuration;
        private PeopleManagementContext mPeopleManagementContext;
        public PeopleService(IConfiguration configuration, IRabbitMqService rabbitMqService)
        {
            _configuration = configuration;
            mRabbitMqService = rabbitMqService;
            mPeopleManagementContext = new PeopleManagementContext(configuration);
        }

        public List<Person> GetAll()
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var result = repo.GetPeople();
            return result;
        }

        public int GetAllEverCount()
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var result = repo.GetPeople().Count();
            return result;
        }

        public int GetAliveCount()
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var result = repo.GetPeople().Where(p => !p.DeathDate.HasValue).Count();
            return result;
        }

        public int GetDeathCount()
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var result = repo.GetPeople().Where(p => p.DeathDate.HasValue).Count();
            return result;
        }

        public int GetInAgeRangeCount(DateTime currentDate, int minAge, int maxAge)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var result = repo.GetPeopleInAgeRange(currentDate, minAge, maxAge).Count();
            return result;
        }

        public int GetMateCount()
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var result = repo.GetPeople().Where(p => p.Mate.HasValue && !p.DeathDate.HasValue).Count();
            return result;
        }

        public int GetWithoutMateCount(DateTime currentDate)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            int result = FilterMates(currentDate, repo.GetPeople()); ;
            return result;
        }

        public static int FilterMates(DateTime currentDate, List<Person> people)
        {
            return people.Where(p => !p.Mate.HasValue && !p.DeathDate.HasValue && p.BirthDate.Value.Date <= currentDate.AddYears(-18).Date).Count();
        }

        public List<Person> GetAll(int amount, int skip)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            return repo.GetPeople(amount, skip);
        }

        public List<Person> GetSingles(int amount, int skip, DateTime date, bool gender)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            return repo.GetSinglePeople(amount, skip, date, gender);
        }

        public List<Person> Seed(int amount)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var seededPeople = repo.SeedPeople(amount);
            foreach (var person in seededPeople)
            {
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.seeded", true);
            }
            return seededPeople;
        }

        public void PerformDailyActivityOnAllPeople(DateTime date)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var people = repo.GetLivingPeople();
            foreach (var person in people)
            {
                var singles = GetSingles(2, 0, date, !person.Gender.Value);
                PerformDailyActivity(person, date, singles);
            }
        }

        public void PerformDailyActivity(Person person, DateTime date, List<Person> singles)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            // Only do this if person does not have a mate yet
            FindMate(person, singles, repo, date);
            HaveChild(person, date);
            CheckHealth(person, date);
        }

        private void CheckHealth(Person person, DateTime date)
        {
            person.CheckHealth(date);
            if (person.DeathDate.HasValue)
            {
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.updated", true);
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.died", true);
            }
        }

        private Person HaveChild(Person person, DateTime date)
        {
            if (person.Gender.HasValue && person.Mate.HasValue)
            {
                if (person.Gender.Value)
                {
                    var birthAcheived = person.AttemptProcreation();
                    if (birthAcheived)
                    {
                        var repo = new PeopleRepo(mPeopleManagementContext);
                        var t = repo.SeedPeople(1);
                        mRabbitMqService.sendMessage(new { parent = person, child = t.First(), date = date }, "people_exchange_main.person.concieved", true);
                        mRabbitMqService.sendMessage(t.First(), "people_exchange_main.person.created", true);

                        return person;
                    }
                }

            }
            return null;
        }

        private void FindMate(Person person, List<Person> singles, PeopleRepo repo, DateTime date)
        {
            var dateMinus18 = date.AddYears(-18);
            var dateMinus38 = date.AddYears(-38);
            var pBDay = person.BirthDate;

            var b = 0;
            if (!person.Mate.HasValue && person.BirthDate <= date.AddYears(-18) && person.BirthDate >= date.AddYears(-38))
            {
                //Try and find a mate
                person.AttemptConection(singles);

                // If person has a mate now update person and mate
                if (person.Mate.HasValue)
                {
                    // Saftey check to make sure mate exist
                    var mate = repo.GetPerson(person.Mate.Value);
                    if (mate != null)
                    {
                        // safty check to make sure mate does not already have a mate
                        if (!mate.Mate.HasValue)
                        {
                            repo.UpdatePerson(person);
                            mate.Mate = person.Id;
                            repo.UpdatePerson(mate);
                            mRabbitMqService.sendMessage(person, "people_exchange_main.person.mated", true);
                            mRabbitMqService.sendMessage(mate, "people_exchange_main.person.mated", true);

                        }
                    }
                }
            }
        }

        public Person Add(Person person)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var addedPerson = repo.AddPerson(person);
            mRabbitMqService.sendMessage(person, "people_exchange_main.person.created", true);
            return addedPerson;
        }

        public Person Update(Person person)
        {
            var repo = new PeopleRepo(mPeopleManagementContext);
            var updatedPerson = repo.UpdatePerson(person);
            mRabbitMqService.sendMessage(person, "people_exchange_main.person.updated", true);
            return updatedPerson;
        }
    }
}
