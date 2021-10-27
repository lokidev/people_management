using Xunit;
using PeopleManagement.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PeopleManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PeopleManagementTests.Models;

namespace PeopleManagement.Repos.Tests
{
    public class PeopleRepoTests
    {
        [Fact()]
        public void GetPeopleInAgeRangeTest()
        {
            var data = MockPeople.people.AsQueryable();

            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PeopleManagementContext>();
            mockContext.Setup(c => c.People).Returns(mockSet.Object);

            var repo = new PeopleRepo(mockContext.Object);
            var foundPeople = repo.GetPeopleInAgeRange(MockDates.currentDate, 0, 18);

            Assert.True(foundPeople.Count() == 3);
        }
    }
}