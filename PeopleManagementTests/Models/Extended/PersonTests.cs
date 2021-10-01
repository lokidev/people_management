using Xunit;
using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace PeopleManagement.Models.Tests
{
    public class PersonTests
    {
        [Fact()]
        public void MakeConectionTest()
        {
            var person = new Person();
            person.Id = 1;
            person.Luck = 150;
            person.Gender = true;
            person.BirthDate = DateTime.Now;

            Assert.True(!person.Mate.HasValue);

            var mate = new Person();
            mate.Id = 2;
            mate.Luck = 150;
            mate.Gender = true;
            mate.BirthDate = DateTime.Now;

            var mates = new List<Person>();
            mates.Add(mate);

            person.AttemptConection(mates);

            Assert.True(person.Mate.HasValue);
        }

        [Fact()]
        public void FailConectionTest()
        {
            var person = new Person();
            person.Id = 1;
            person.Luck = 50;
            person.Gender = true;
            person.BirthDate = DateTime.Now;

            Assert.True(!person.Mate.HasValue);

            var mate = new Person();
            mate.Id = 2;
            mate.Luck = 50;
            mate.Gender = true;
            mate.BirthDate = DateTime.Now;

            var mates = new List<Person>();
            mates.Add(mate);

            person.AttemptConection(mates);

            Assert.True(!person.Mate.HasValue);
        }

        [Fact()]
        public void PassProcreationTest()
        {
            var person = new Person();
            person.Id = 1;
            person.Luck = 150;
            Assert.True(person.AttemptProcreation());
        }

        [Fact()]
        public void FailProcreationTest()
        {
            var person = new Person();
            person.Id = 1;
            person.Luck = 25;
            Assert.False(person.AttemptProcreation());
        }
    }
}