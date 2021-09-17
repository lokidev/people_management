using QuickTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickTechApi.Repos;
using Microsoft.Extensions.Configuration;

namespace QuickTechApi.Services
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
            using (var db = new ResumeContext(_configuration))
            {
                var t = new TechRepo(db);
                return t.GetProduts();
            }
        }
    }
}
