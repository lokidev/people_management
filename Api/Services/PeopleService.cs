using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Repos;
using PeopleManagement.Messaging.Interfaces;
using Microsoft.Extensions.Configuration;
using PeopleManagement.Messaging.Configurations;
using PeopleManagement.Services.Interfaces;

namespace PeopleManagement.Services
{
    public class PeopleService : IPeopleService
    {
        private IRabbitMqService mRabbitMqService;
        private readonly IConfiguration _configuration;
        public PeopleService(IConfiguration configuration, IRabbitMqService rabbitMqService)
        {
            _configuration = configuration;
            mRabbitMqService = rabbitMqService;
        }

        public IEnumerable<Person> GetAll()
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                var result = repo.GetPeople();
                return result;
            }
        }

        public IEnumerable<Person> GetAll(int amount, int skip)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                return repo.GetPeople(amount, skip);
            }
        }

        public IEnumerable<Person> GetSingles(int amount, int skip)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                return repo.GetSinglePeople(amount, skip);
            }
        }

        public IEnumerable<Person> Seed(int amount)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                var seededPeople = repo.SeedPeople(amount);
                foreach (var person in seededPeople)
                {
                    mRabbitMqService.sendMessage(person, "people_exchange_main.person.seeded", true);
                }
                return seededPeople;
            }
        }

        public void PerformDailyActivityOnAllPeople()
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                var people = repo.GetPeople();
                foreach (var person in people)
                {
                    this.PerformDailyActivity(person);
                }
            }
        }

        public void PerformDailyActivity(Person person)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                var singles = GetSingles(20, 0)
                .Where(p => p.Gender != person.Gender);
                person.AttemptConection(singles);
                repo.UpdatePerson(person);
            }
        }

        public Person Add(Person person)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                var addedPerson = repo.AddPerson(person);
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.created", true);
                return addedPerson;
            }
        }

        public Person Update(Person person)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var repo = new PeopleRepo(db);
                var updatedPerson = repo.UpdatePerson(person);
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.updated", true);
                return updatedPerson;
            }
        }
    }
}
