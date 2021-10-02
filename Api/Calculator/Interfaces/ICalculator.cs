using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Calculations.Interfaces
{
    public interface ICalculator
    {
        bool ShouldDie(double health, double luck);
        bool MadeConnection(double personLuck, double potentialMateLuck);
        bool ConcievedChild(double luck);
    }
}
