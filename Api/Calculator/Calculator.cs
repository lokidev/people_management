using PeopleManagement.Calculations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Calculations
{
    public class Calculator : ICalculator
    {
        public bool ShouldDie(double health, double luck)
        {
            var divisableBy = 3;
            float successRate = 50;

            var healthAndLuck = health + luck;
            var chance = RandomPercentCalculator();
            var totalWithChance = healthAndLuck + chance;

            var dividedPersentage = totalWithChance / divisableBy;

            return dividedPersentage < successRate;
        }

        public bool ConcievedChild(double luck)
        {
            var divisableBy = 2;
            float successRate = 90;

            var personLuck = luck;
            var chance = RandomPercentCalculator();

            var totalWithChance = personLuck + chance;

            var dividedPersentage = totalWithChance / divisableBy;

            return dividedPersentage > successRate;
        }

        public bool MadeConnection(double personLuck, double potentialMateLuck)
        {
            var divisableBy = 4;
            float successRate = 85;

            var personAttraction = RandomPercentCalculator();
            var mateAttraction = RandomPercentCalculator();

            var totalLuck = personLuck + potentialMateLuck;
            var totalAttraction = personAttraction + mateAttraction;
            var total = totalLuck + totalAttraction;

            var dividedPersentage = total / divisableBy;

            return dividedPersentage > successRate;
        }

        public static float RandomPercentCalculator()
        {
            Random r = new Random();
            int rInt = r.Next(25, 100); //for ints
            return rInt;
        }
    }
}
