using PeopleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Services
{
    public interface IPeopleService
    {
        public ICollection<Person> GetAll();
        public int Seed(int amount);
    }
}
