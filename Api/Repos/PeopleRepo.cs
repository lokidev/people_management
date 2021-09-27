using System.Data;
using System.Data.Common;
using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Repos
{
    public class PeopleRepo: IPeopleRepo
    {
        private PeopleManagementContext db;

        public PeopleRepo(PeopleManagementContext db)
        {
            this.db = db;
        }

        public IEnumerable<Person> GetPeople(int amount, int skip)
        {
            if (db != null)
            {
                List<Person> employees = new List<Person>();

                var result = db.People
                    .OrderByDescending(x => x.Id)
                    .Take(amount)
                    .Skip(skip)
                    .ToList();

                return result;
            }

            return null;
        }

        public IEnumerable<Person> GetSinglePeople(int amount, int skip)
        {
            if (db != null)
            {
                List<Person> employees = new List<Person>();

                var result = db.People
                    .Where(x => !x.Mate.HasValue)
                    .OrderByDescending(x => x.Id)
                    .Take(amount)
                    .Skip(skip)
                    .ToList();

                return result;
            }

            return null;
        }

        public IEnumerable<Person> SeedPeople(int amount){
            if (db != null)
            {
                var existing = db.People.Count();
                var createdPeople = new List<Person>();
                for (int i = existing + 1; i < existing + 1 + amount; i++)
                {
                    var person = db.People.Add(new Person() { CreationDate = DateTime.Now, IdentificationTags = "{}", DestructionDate = null });
                    db.SaveChanges();
                    createdPeople.Add(person.Entity);
                }
                return createdPeople;
            }
            return new List<Person>();
        }

        public Person AddPerson(Person person)
        {
            if (db != null)
            {
                var addedPerson = db.People.Add(person);
                db.SaveChanges();

                return addedPerson.Entity;
            }
            return null;
        }

        public Person UpdatePerson(Person person)
        {
            if (db != null)
            {
                var updatedPerson = db.People.Update(person);
                db.SaveChanges();
                
                return updatedPerson.Entity;
            }
            return null;
        }
    }
}
