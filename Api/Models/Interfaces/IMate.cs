using System.Collections.Generic;

namespace PeopleManagement.Models
{
    public interface IMate
    {
        Person AttemptConection(IEnumerable<Person> pMates);
        bool AttemptProcreation();
    }
}