using System;
using System.Collections.Generic;
using System.Text;
using PeopleManagement.Models;

namespace PeopleManagementTests.Models
{
    public class MockPeople
    {
        public static List<Person> people
        {
            get
            {
                var toYoung = new Person();
                toYoung.Id = 1;
                toYoung.BirthDate = new DateTime(2018, 1, 1);
                toYoung.FirstName = "toYoung";

                var oldEnough = new Person();
                oldEnough.Id = 2;
                oldEnough.BirthDate = new DateTime(2000, 1, 1);
                oldEnough.FirstName = "oldEnough";

                var justOldEnough = new Person();
                justOldEnough.Id = 3;
                justOldEnough.BirthDate = new DateTime(2002, 1, 1);
                justOldEnough.FirstName = "justOldEnough";

                var oldEnoughWithMate = new Person();
                oldEnoughWithMate.Id = 4;
                oldEnoughWithMate.BirthDate = new DateTime(2002, 1, 1);
                oldEnoughWithMate.Mate = 1;
                oldEnoughWithMate.FirstName = "oldEnoughWithMate";

                var oldEnoughButDead = new Person();
                oldEnoughButDead.Id = 5;
                oldEnoughButDead.BirthDate = new DateTime(2002, 1, 1);
                oldEnoughButDead.DeathDate = new DateTime(2020, 1, 1);
                oldEnoughButDead.FirstName = "oldEnoughButDead";

                var person3 = new Person();
                person3.BirthDate = new DateTime(2007, 1, 1);

                return new List<Person> { toYoung, oldEnough, oldEnoughWithMate, oldEnoughButDead, justOldEnough };
            }
        }
    }
}
