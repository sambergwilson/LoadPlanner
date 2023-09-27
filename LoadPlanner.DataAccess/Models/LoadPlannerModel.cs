using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlanner.DataAccess.Models
{
    public class LoadPlannerModel
    {
        public int LoadID { get; set; }
        public int LoadCode { get; set; }
        public int RouteNumber { get; set; }
        public int LocationCode { get; set; }
        public string LocationDescription { get; set; }
        public string LocationAddress { get; set; }
        public string DriverName { get; set; }
        public int DriverCode { get; set; }
        public string TruckCode { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool IsArchived { get; set; }

        public LoadPlannerModel(int loadId, int routeId, int locCode, string locDescription, string locAddress, string driverName, int driverCode, string truckCode, bool isAssigned, bool isDeleted, DateTime assignedDate, DateTime completedDate, bool isArchived) 
        {
            LoadID = loadId;
            RouteNumber = routeId;
            LocationCode = locCode;
            LocationDescription = locDescription;
            LocationAddress = locAddress;
            DriverName = driverName;
            DriverCode = driverCode;
            TruckCode = truckCode;
            IsAssigned = isAssigned;
            IsDeleted = isDeleted;
            AssignedDate = assignedDate;
            CompletedDate = completedDate;
            IsArchived = isArchived;
        }

        public LoadPlannerModel() { }
    }
}
