using QuickTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickTechApi.Services
{
    public interface ITechService
    {
        public ICollection<Tech> GetAll();
    }
}
