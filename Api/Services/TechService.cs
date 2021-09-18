using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Repos;
using Microsoft.Extensions.Configuration;

namespace PeopleManagement.Services
{
    public class TechService : ITechService
    {
        private readonly IConfiguration _configuration;

        public TechService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<Tech> GetAll()
        {
            using (var db = new PeopleManagementContext(_configuration))
            {
                var t = new TechRepo(db);
                return t.GetProduts();
            }
        }
    }
}
