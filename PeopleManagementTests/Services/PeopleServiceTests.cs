using Xunit;
using PeopleManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PeopleManagement.Repos;
using PeopleManagement.Models;
using System.Linq;

namespace PeopleManagement.Services.Tests
{
    public class PeopleServiceTests
    {
        public DateTime currentDate = new DateTime(2020, 1, 1);
        public DateTime compareDate { get { return currentDate.AddYears(-18); } }

        public List<Person> people { 
            get 
            {
                var toYoung = new Person();
                toYoung.Id = 1;
                toYoung.BirthDate = new DateTime(2018, 1, 1);

                var oldEnough = new Person();
                oldEnough.Id = 2;
                oldEnough.BirthDate = new DateTime(2000, 1, 1);

                var justOldEnough = new Person();
                justOldEnough.Id = 3;
                justOldEnough.BirthDate = new DateTime(2002, 1, 1);

                var oldEnoughWithMate = new Person();
                oldEnoughWithMate.Id = 4;
                oldEnoughWithMate.BirthDate = new DateTime(2002, 1, 1);
                oldEnoughWithMate.Mate = 1;

                var oldEnoughButDead = new Person();
                oldEnoughButDead.Id = 5;
                oldEnoughButDead.BirthDate = new DateTime(2002, 1, 1);
                oldEnoughButDead.DeathDate = new DateTime(2020, 1, 1);

                var person3 = new Person();
                person3.BirthDate = new DateTime(2007, 1, 1);

                return new List<Person> { toYoung, oldEnough, oldEnoughWithMate, oldEnoughButDead, justOldEnough };
            } 
        }

        [Fact()]
        public void ToYoungToMate()
        {
            var debugDate = compareDate;
            var subPeople = this.people.Where(p => p.Id == 1).ToList();
            var matesFound = PeopleService.FilterMates(this.currentDate, subPeople);
            Assert.True(matesFound == 0);
        }

        [Fact()]
        public void OldEnoughButHasMate()
        {
            var debugDate = compareDate;
            var subPeople = this.people.Where(p => p.Id == 4).ToList();
            var matesFound = PeopleService.FilterMates(this.currentDate, subPeople);
            Assert.True(matesFound == 0);
        }

        [Fact()]
        public void OldEnoughToMate()
        {
            var debugDate = compareDate;
            var subPeople = this.people.Where(p => p.Id == 2).ToList();
            var matesFound = PeopleService.FilterMates(this.currentDate, subPeople);
            Assert.True(matesFound == 1);
        }

        [Fact()]
        public void YearsEqualToMateRequirements()
        {
            var debugDate = compareDate;
            var subPeople = this.people.Where(p => p.Id == 3).ToList();
            var matesFound = PeopleService.FilterMates(this.currentDate, subPeople);
            Assert.True(matesFound == 1);
        }

        [Fact()]
        public void ToDeadToMate()
        {
            var debugDate = compareDate;
            var subPeople = this.people.Where(p => p.Id == 5).ToList();
            var matesFound = PeopleService.FilterMates(this.currentDate, subPeople);
            Assert.True(matesFound == 0);
        }

        [Fact()]
        public void CanMate()
        {
            var matesFound = PeopleService.FilterMates(this.currentDate, this.people);
            Assert.True(matesFound == 2);
        }
    }
}