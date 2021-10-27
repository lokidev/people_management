using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManagement.Services.Interfaces
{
    public interface IPeopleService
    {
        List<Person> GetAll();
        int GetAllEverCount();
        int GetAliveCount();
        int GetDeathCount();
        int GetMateCount();
        int GetWithoutMateCount(DateTime currentDate);
        int GetInAgeRangeCount(DateTime currentDate, int minAge, int maxAge);
        List<Person> GetAll(int amount, int skip);
        List<Person> GetSingles(int amount, int skip, DateTime date, bool gender);
        List<Person> Seed(int amount);
        void PerformDailyActivityOnAllPeople(DateTime date);
        Person Add(Person person);
        Person Update(Person person);
    }
}
