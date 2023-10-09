using LoadPlanner.DataAccess.Context;
using LoadPlanner.DataAccess.Models;
using LoadPlanner.DataAccess.Repositories;
using LoadPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoadPlanner.Controllers
{
    public class LoadPlannerController : Controller
    {
        private readonly LoadPlannerRepository _repo;

        public LoadPlannerController()
        {
            _repo = new LoadPlannerRepository();
        }

        public IActionResult Index()
        {
            LoadPlannerViewModel viewModel = new LoadPlannerViewModel();
            viewModel.LoadList = GetAllLoads();

            // This is saying the first or default of the load list
            viewModel.CurrentLoad = viewModel.LoadList.FirstOrDefault();

            return View(viewModel);
        }

        public IActionResult CreatePage() 
        {
            return View("CreatePage");
        }

        // Reason this is private is beacuse I will only be using this method on this view
        private List<LoadPlannerModel>? GetAllLoads()
        {
            return _repo.GetAllLoads();
        }

        public IActionResult Delete(int loadID)
        {
            LoadPlannerViewModel viewModel = new LoadPlannerViewModel();
            var currentLoad = _repo.GetLoadById(loadID);
            if (currentLoad != null) 
            {
                _repo.Delete(currentLoad.LoadID);
                viewModel.IsActionSuccess = true;
                viewModel.ActionMessage = "Load has been deleted successfully.";
            }
            else 
            {
                viewModel.IsActionSuccess = false;
                viewModel.ActionMessage = "Error deleting the load please call the Administrator!";
            }

            return View("Index", viewModel);
        }

        /*public IActionResult CreatePage(int loadCode, int routeNumber, int locationCode, string locationDescription, string locationAddress)
        {
            LoadPlannerViewModel model = new LoadPlannerViewModel();
            var newLoad = new LoadPlannerModel()
            {
                LoadCode = loadCode,
                RouteNumber = routeNumber,
                LocationCode = locationCode,
                LocationDescription = locationDescription,
                LocationAddress = locationAddress
            };

            if (newLoad != null)
            {
                _repo.Create(newLoad);
                
                model.IsActionSuccess = true;
                model.ActionMessage = "Created a new load Successfully.";
            }
            else
            {
                model.IsActionSuccess = false;
                model.ActionMessage = "Failed to create load.";
            }

            return View("Index");
        }*/

        public IActionResult Update(LoadPlannerModel load)
        {
            LoadPlannerViewModel loadViewModel = new LoadPlannerViewModel();    
            _repo.AssignLoad(load);


            return View("Index", loadViewModel);
        }
    }
}
