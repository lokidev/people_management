using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManagement.Services.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAll();
        IEnumerable<Person> GetAll(int amount, int skip);
        IEnumerable<Person> GetSingles(int amount, int skip, DateTime date, bool gender);
        IEnumerable<Person> Seed(int amount);
        Task PerformDailyActivityOnAllPeople(DateTime date);
        Person Add(Person person);
        Person Update(Person person);
    }
}
