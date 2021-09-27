using System.Data;
using System.Data.Common;
using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManagement.Repos
{
    public interface IPeopleRepo
    {
        IEnumerable<Person> GetPeople(int amount, int skip);

        IEnumerable<Person> GetSinglePeople(int amount, int skip);

        IEnumerable<Person> SeedPeople(int amount);

        Person AddPerson(Person person);

        Person UpdatePerson(Person person);
    }
}
