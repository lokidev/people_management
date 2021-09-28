using PeopleManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace PeopleManagement.Models
{
    public partial class Person: IPerson
    {
        public Person AttemptConection(IEnumerable<Person> pMates)
        {
            foreach(var mate in pMates)
            {
                if (!mate.Mate.HasValue)
                {
                    this.Mate = mate.Id;
                    return this;
                }
            }
            return this;
        }

        public bool AttemptProcreation()
        {
            throw new NotImplementedException();
        }

        public void CollectCompensation()
        {
            throw new NotImplementedException();
        }

        public void CollectResource()
        {
            throw new NotImplementedException();
        }

        public Person ConsumeFood()
        {
            throw new NotImplementedException();
        }

        public Person ConsumeProducts()
        {
            throw new NotImplementedException();
        }

        public void FindJob()
        {
            throw new NotImplementedException();
        }

        public void FindShelter()
        {
            throw new NotImplementedException();
        }

        public Person PayForShelter()
        {
            throw new NotImplementedException();
        }

        public void ProduceFood()
        {
            throw new NotImplementedException();
        }

        public void ProduceProduct()
        {
            throw new NotImplementedException();
        }

        public Person UpgradeShelter()
        {
            throw new NotImplementedException();
        }
    }
}
