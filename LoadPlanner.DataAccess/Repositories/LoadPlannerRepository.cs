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

        public int Update(LoadPlannerModel load)
        {
            LoadPlannerModel existingLoad = _context.LoadModel.Find(load.LoadID);

            existingLoad.LoadCode = load.LoadCode;
            existingLoad.RouteNumber = load.RouteNumber;
            existingLoad.LocationCode = load.LocationCode;
            existingLoad.LocationDescription = load.LocationDescription;
            existingLoad.LocationAddress = load.LocationAddress;
            existingLoad.DriverName = load.DriverName;
            existingLoad.TruckCode = load.TruckCode;
            existingLoad.IsAssigned = load.IsAssigned;
            existingLoad.IsDeleted = load.IsDeleted;
            existingLoad.AssignedDate = load.AssignedDate;
            existingLoad.CompletedDate = load.CompletedDate;
            existingLoad.IsArchived = load.IsArchived;

            _context.SaveChanges();

            return existingLoad.LoadID;
        }

        public bool Delete(int loadID)
        {
            LoadPlannerModel load = _context.LoadModel.Find(loadID);

            _context.Remove(load);
            _context.SaveChanges();

            return true;
        }

        public List<LoadPlannerModel> GetAllLoads()
        {
            List<LoadPlannerModel> loadList = _context.LoadModel.ToList();

            return loadList;
        }

        public LoadPlannerModel GetLoadById(int loadID)
        {
            LoadPlannerModel loaded = _context.LoadModel.Find(loadID);

            return loaded;
        }
    }
}
