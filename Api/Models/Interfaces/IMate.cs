using System.Collections.Generic;

namespace PeopleManagement.Models
{
    public interface IMate
    {
        Person AttemptConection(List<Person> pMates);
        bool AttemptProcreation();
    }
}