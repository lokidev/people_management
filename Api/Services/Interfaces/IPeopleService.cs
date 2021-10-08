﻿using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManagement.Services.Interfaces
{
    public interface IPeopleService
    {
        List<Person> GetAll();
        List<Person> GetAll(int amount, int skip);
        List<Person> GetSingles(int amount, int skip, DateTime date, bool gender);
        List<Person> Seed(int amount);
        void PerformDailyActivityOnAllPeople(DateTime date);
        Person Add(Person person);
        Person Update(Person person);
    }
}
