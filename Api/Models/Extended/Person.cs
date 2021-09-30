using PeopleManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace PeopleManagement.Models
{
    public partial class Person : IPerson
    {
        public Person AttemptConection(IEnumerable<Person> pMates)
        {
            // Check if the person you are looking for already has a mate
            if (!Mate.HasValue)
            {
                // Filter out people with mates already and current person
                pMates = pMates.Where(p => p.Id != this.Id && !p.Mate.HasValue);

                foreach (var mate in pMates)
                {
                    // Variables for calculation
                    var personAttraction = RandomPercentCalculator();
                    var mateAttraction = RandomPercentCalculator();
                    var personLuck = Luck;
                    var mateLuck = mate.Luck;

                    //Calculate chance of connection
                    var loveChance = (personAttraction + mateAttraction + personLuck + mateLuck) / 4;

                    // If chance is 80 or better make connection
                    if (loveChance >= 85)
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
            if ((this.Luck.Value + RandomPercentCalculator())/2 >= 90)
            {
                return true;
            }
            else
            {
                return false;
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
            int rInt = r.Next(50, 100); //for ints
            return rInt;
        }
    }
}
