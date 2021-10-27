using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleManagementTests.Models
{
    public class MockDates
    {
        public static DateTime currentDate = new DateTime(2020, 1, 1);
        public static DateTime compareDate { get { return currentDate.AddYears(-18); } }
    }
}
