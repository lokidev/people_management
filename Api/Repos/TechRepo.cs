using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Repos
{
    public class TechRepo
    {
        private PeopleManagementContext db;

        public TechRepo(PeopleManagementContext db)
        {
            this.db = db;
        }

        public List<Tech> GetProduts()
        {
            if (db != null)
            {
                List<Tech> employees = new List<Tech>();

                var result = db.Teches.OrderByDescending(x => x.TechName).ToList();

                return result;
            }

            return null;
        }
    }
}
