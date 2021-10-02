using PeopleManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using PeopleManagement.Calculations;
using PeopleManagement.Calculations.Interfaces;

#nullable disable

namespace PeopleManagement.Models
{
    public partial class Person : IPerson
    {
        private ICalculator mCalculator;
        public Person()
        {
            mCalculator = new Calculator();
        }

        public Person AttemptConection(IEnumerable<Person> pMates)
        {
            // Check if the person you are looking for already has a mate
            if (!Mate.HasValue)
            {
                // Filter out people with mates already and current person
                pMates = pMates.Where(p => p.Id != this.Id && !p.Mate.HasValue);

                foreach (var mate in pMates)
                {
                    if (mCalculator.MadeConnection(Luck.Value, mate.Luck.Value))
                    {
                        this.Mate = mate.Id;
                        break;
                    }
                }
            }
            return this;
        }

        public bool AttemptProcreation()
        {
            if (mCalculator.ConcievedChild(Luck.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }

        public void CheckHealth(DateTime date)
        {
            if (BirthDate.Value.AddYears(85) < date)
            {
                DeathDate = date;
            }
            else
            {
                if (mCalculator.ShouldDie(Health.Value, Luck.Value))
                {
                    DeathDate = date;
                }
            }
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

        public static float RandomPercentCalculator()
        {
            Random r = new Random();
            int rInt = r.Next(25, 100); //for ints
            return rInt;
        }
    }
}
