using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Services.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAll();
        IEnumerable<Person> GetAll(int amount, int skip);
        IEnumerable<Person> GetSingles(int amount, int skip);
        IEnumerable<Person> Seed(int amount);
        void PerformDailyActivityOnAllPeople();
        Person Add(Person person);
        Person Update(Person person);
    }
}
