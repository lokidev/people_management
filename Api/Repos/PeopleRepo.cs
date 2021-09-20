using System.Data;
using System.Data.Common;
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

        public int SeedPeople(int amount){
            if (db != null)
            {
                var existing = db.People.Count();
                for (int i = existing + 1; i < existing + 1 + amount; i++)
                {
                    db.People.Add(new Person() { FirstName = "Josh-" + i, LastName = "French-" + i, Gender = true, Health = 100.00, Hunger = 100.00, Security = 100.00, Luck = 100.00, CreationDate = DateTime.Now, IdentificationTags = "{}", DestructionDate = null });
                }
                db.SaveChanges();
                return db.People.Count();
            }
            return 0;
        }
    }
}
