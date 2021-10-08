using PeopleManagement.Models;
using System;
using System.Collections.Generic;

namespace PeopleManagement.Repos
{
    public interface IPeopleRepo
    {
        Person GetPerson(int id);
        List<Person> GetPeople();
        List<Person> GetPeople(int amount, int skip);
        List<Person> GetLivingPeople();
        List<Person> GetLivingPeople(int amount, int skip);
        List<Person> GetSinglePeople(int amount, int skip, DateTime date, bool gender);
        List<Person> SeedPeople(int amount);
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
    }
}
