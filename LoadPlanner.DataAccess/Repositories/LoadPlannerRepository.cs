using LoadPlanner.DataAccess.Context;
using LoadPlanner.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlanner.DataAccess.Repositories
{
    public class LoadPlannerRepository
    {
        private readonly LoadPlannerContext _context;

        public LoadPlannerRepository()
        {
            _context = new LoadPlannerContext();
        }
    }
}
