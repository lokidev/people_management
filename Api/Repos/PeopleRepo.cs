using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Repos
{
    public class PeopleRepo
    {
        private PeopleManagementContext db;

        public PeopleRepo(PeopleManagementContext db)
        {
            this.db = db;
        }

        public List<Person> GetPeople()
        {
            if (db != null)
            {
                List<Person> employees = new List<Person>();

                var result = db.People.OrderByDescending(x => x.Id).ToList();

                return result;
            }

            return null;
        }
    }
}
