using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Models.Requests
{
    public class AgeRange
    {
        public DateTime currentDate { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }
    }

    public class WorldDate
    {
        public DateTime currDate { get; set; }
    }
}
