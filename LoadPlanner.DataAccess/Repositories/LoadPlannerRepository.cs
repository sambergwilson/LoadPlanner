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

        // Ask about everthing here.
        public int Create(LoadPlannerModel load)
        {
            _context.Add(load);
            _context.SaveChanges();

            return load.LoadID;
        }

        public int AssignedLoad(LoadPlannerModel load)
        {
            LoadPlannerModel existingLoad = _context.LoadModel.Find(load.LoadID)!;

            if (existingLoad != null)
            {
                existingLoad.DriverName = load.DriverName;
                existingLoad.TruckCode = load.TruckCode;
                existingLoad.IsAssigned = true;
                existingLoad.AssignedDate = DateTime.UtcNow;

                _context.SaveChanges();
            }

            return load.LoadID;
        }

        public int UnassignedLoad(LoadPlannerModel load)
        {
            return load.LoadCode;
        }

        public bool Delete(int loadID)
        {
            LoadPlannerModel load = _context.LoadModel.Find(loadID)!;

            if (load != null)
            {
                load.IsDeleted = true;
                _context.SaveChanges();
            }

            return true;
        }

        public List<LoadPlannerModel> GetAllLoads()
        {
            List<LoadPlannerModel> loadList = _context.LoadModel.ToList();

            return loadList;
        }

        public LoadPlannerModel GetLoadById(int loadID)
        {
            LoadPlannerModel loaded = _context.LoadModel.Find(loadID)!;

            return loaded;
        }

     }
}
