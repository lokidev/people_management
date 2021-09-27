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

        public IEnumerable<Person> GetAll(int amount, int skip)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                return p.GetPeople(amount, skip);
            }
        }

        public IEnumerable<Person> GetSingles(int amount, int skip)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                return p.GetSinglePeople(amount, skip);
            }
        }

        public IEnumerable<Person> Seed(int amount)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                var seededPeople = p.SeedPeople(amount);
                foreach (var person in seededPeople)
                {
                    mRabbitMqService.sendMessage(person, "people_exchange_main.person.seeded", true);
                }
                return seededPeople;
            }
        }

        public Person Add(Person person)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                var addedPerson = p.AddPerson(person);
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.created", true);
                return addedPerson;
            }
        }

        public Person Update(Person person)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                var updatedPerson = p.UpdatePerson(person);
                mRabbitMqService.sendMessage(person, "people_exchange_main.person.updated", true);
                return updatedPerson;
            }
        }
    }
}
