using QuickTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickTechApi.Repos
{
    public class TechRepo
    {
        private ResumeContext db;

        public TechRepo(ResumeContext db)
        {
            this.db = db;
        }

        public List<Tech> GetProduts()
        {
            if (db != null)
            {
                List<Tech> employees = new List<Tech>();

                var result = db.Teches.OrderByDescending(x => x.TechName).ToList();

                return result;
            }

            return null;
        }
    }
}
