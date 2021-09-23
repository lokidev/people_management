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

        public ICollection<Person> GetAll()
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                return p.GetPeople();
            }
        }

        public List<Person> Seed(int amount)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                var seededPeople = p.SeedPeople(amount);
                foreach (var person in seededPeople)
                {
                    mRabbitMqService.sendMessage(person, "people_exchange_main.person.created", true);
                }
                return seededPeople;
            }
        }
    }
}
