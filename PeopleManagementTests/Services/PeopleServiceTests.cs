using Xunit;
using PeopleManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PeopleManagement.Repos;
using PeopleManagement.Models;
using System.Linq;
using PeopleManagementTests.Models;

namespace PeopleManagement.Services.Tests
{
    public class PeopleServiceTests
    {
        [Fact()]
        public void ToYoungToMate()
        {
            var debugDate = MockDates.compareDate;
            var subPeople = MockPeople.people.Where(p => p.Id == 1).ToList();
            var matesFound = PeopleService.FilterMates(MockDates.currentDate, subPeople);
            Assert.True(matesFound == 0);
        }

        [Fact()]
        public void OldEnoughButHasMate()
        {
            var debugDate = MockDates.compareDate;
            var subPeople = MockPeople.people.Where(p => p.Id == 4).ToList();
            var matesFound = PeopleService.FilterMates(MockDates.currentDate, subPeople);
            Assert.True(matesFound == 0);
        }

        [Fact()]
        public void OldEnoughToMate()
        {
            var debugDate = MockDates.compareDate;
            var subPeople = MockPeople.people.Where(p => p.Id == 2).ToList();
            var matesFound = PeopleService.FilterMates(MockDates.currentDate, subPeople);
            Assert.True(matesFound == 1);
        }

        [Fact()]
        public void YearsEqualToMateRequirements()
        {
            var debugDate = MockDates.compareDate;
            var subPeople = MockPeople.people.Where(p => p.Id == 3).ToList();
            var matesFound = PeopleService.FilterMates(MockDates.currentDate, subPeople);
            Assert.True(matesFound == 1);
        }

        [Fact()]
        public void ToDeadToMate()
        {
            var debugDate = MockDates.compareDate;
            var subPeople = MockPeople.people.Where(p => p.Id == 5).ToList();
            var matesFound = PeopleService.FilterMates(MockDates.currentDate, subPeople);
            Assert.True(matesFound == 0);
        }

        [Fact()]
        public void CanMate()
        {
            var matesFound = PeopleService.FilterMates(MockDates.currentDate, MockPeople.people);
            Assert.True(matesFound == 2);
        }
    }
}