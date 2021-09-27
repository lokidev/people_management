using PeopleManagement.Services.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace PeopleManagement.Models
{
    public partial class Person: IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public double? Luck { get; set; }
        public double? Health { get; set; }
        public double? Hunger { get; set; }
        public double? Security { get; set; }
        public double? AvailableFood { get; set; }
        public double? AvailableResources { get; set; }
        public int? Mate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public DateTime? DestructionDate { get; set; }
        public string IdentificationTags { get; set; }

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
