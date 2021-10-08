using System.Data;
using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Repos
{
    public class PeopleRepo : IPeopleRepo
    {
        protected readonly PeopleManagementContext db;

        public PeopleRepo(PeopleManagementContext dbContext)
        {
            this.db = dbContext;
        }

        public List<Person> GetPeople()
        {
            if (db != null)
            {
                var result = db.People
                    .OrderByDescending(x => x.Id)
                    .ToList();

                return result;
            }

            return null;
        }

        public Person GetPerson(int id)
        {
            if (db != null)
            {
                var result = db.People.Find(id);

                return result;
            }

            return null;
        }

        public List<Person> GetPeople(int amount, int skip)
        {
            if (db != null)
            {
                return db.People
                    .OrderBy(x => x.Id)
                    .Take(amount)
                    .Skip(skip)
                    .ToList();
            }

            return null;
        }

        public List<Person> GetLivingPeople()
        {
            if (db != null)
            {
                return db.People.Where(x => !x.DeathDate.HasValue)
                    .OrderBy(x => x.Id)
                    .ToList();
            }

            return null;
        }

        public List<Person> GetLivingPeople(int amount, int skip)
        {
            if (db != null)
            {
                return db.People.Where(x => !x.DeathDate.HasValue)
                    .OrderBy(x => x.Id)
                    .Take(amount)
                    .Skip(skip)
                    .ToList();
            }

            return null;
        }

        public List<Person> GetSinglePeople(int amount, int skip, DateTime date, bool gender)
        {
            if (db != null)
            {
                var result = db.People
                    .Where(x => !x.Mate.HasValue && 
                        x.BirthDate.HasValue &&
                        !x.DeathDate.HasValue &&
                        x.Gender.HasValue && 
                        x.BirthDate.Value < date.AddYears(-18) && 
                        x.Gender.Value == gender)
                    //.Where(x => x.BirthDate.Value < date.AddYears(-18) && x.Gender.Value == gender)
                    .OrderBy(o => Guid.NewGuid())
                    .Take(amount)
                    .Skip(skip)
                    .ToList();

                return result;
            }

            return null;
        }

        public List<Person> GetAdultPeople(int amount, int skip, DateTime date)
        {
            if (db != null)
            {
                var result = db.People
                    .Where(x => x.BirthDate.Value < date.AddYears(-18))
                    .OrderBy(x => x.Id)
                    .Take(amount)
                    .Skip(skip)
                    .ToList();

                return result;
            }

            return null;
        }

        public List<Person> SeedPeople(int amount)
        {
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
