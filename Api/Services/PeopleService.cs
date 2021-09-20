using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Repos;
using Microsoft.Extensions.Configuration;

namespace PeopleManagement.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IConfiguration _configuration;

        public PeopleService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<Person> GetAll()
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                return p.GetPeople();
            }
        }

        public int Seed(int amount)
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var p = new PeopleRepo(db);
                return p.SeedPeople(amount);
            }
        }
    }
}
