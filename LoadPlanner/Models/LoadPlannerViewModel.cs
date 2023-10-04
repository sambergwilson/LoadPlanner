using LoadPlanner.DataAccess.Models;
using LoadPlanner.DataAccess.Repositories;
using LoadPlanner.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace LoadPlanner.Models
{
    public class LoadPlannerViewModel
    {
        public List<LoadPlannerModel>? LoadList { get; set; }

        public LoadPlannerModel? CurrentLoad { get; set; }

        public bool IsActionSuccess { get; set; }

        public string? ActionMessage { get; set; }

        


    }
}
