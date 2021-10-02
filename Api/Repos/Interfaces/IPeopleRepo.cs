using PeopleManagement.Models;
using System;
using System.Collections.Generic;

namespace PeopleManagement.Repos
{
    public interface IPeopleRepo
    {
        Person GetPerson(int id);
        IEnumerable<Person> GetPeople();
        IEnumerable<Person> GetPeople(int amount, int skip);
        IEnumerable<Person> GetLivingPeople();
        IEnumerable<Person> GetLivingPeople(int amount, int skip);
        IEnumerable<Person> GetSinglePeople(int amount, int skip, DateTime date, bool gender);
        IEnumerable<Person> SeedPeople(int amount);
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
    }
}
