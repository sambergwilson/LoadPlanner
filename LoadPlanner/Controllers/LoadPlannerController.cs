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

            return View("Index", viewModel);
        }

        public IActionResult DeleteLoad(int loadID)
        {
            var currentLoad = loadID;

            if (currentLoad > 0)
            {
                _repo.Delete(loadID);
                /*viewModel.IsActionSuccess = true;
                viewModel.ActionMessage = "Load has been deleted Successfully.";*/
            }
            else
            {
                /*viewModel.IsActionSuccess = false;
                viewModel.ActionMessage = "Error deleting the load please contact the Administrator.";*/
            }

            var updatedList = GetAllLoads();
            var viewModel = new LoadPlannerViewModel();
            viewModel.LoadList = updatedList;


            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult CreatePage() 
        {
            return View("CreatePage");
        }

        [HttpPost]
        public IActionResult CreatePage(int loadCode, int routeNumber, int locationCode, string locationDescription, string locationAddress)
        {
            var newLoad = new LoadPlannerModel()
            {
                LoadCode = loadCode,
                RouteNumber = routeNumber,
                LocationCode = locationCode,
                LocationDescription = locationDescription,
                LocationAddress = locationAddress
            };

            _repo.Create(newLoad);

            var updatedLoadList = GetAllLoads();
            LoadPlannerViewModel viewModel = new LoadPlannerViewModel();

            viewModel.LoadList = updatedLoadList;
            /*if (newLoad != null)
            {
                _repo.Create(newLoad);
                
                model.IsActionSuccess = true;
                model.ActionMessage = "Created a new load Successfully.";
            }
            else
            {
                model.IsActionSuccess = false;
                model.ActionMessage = "Failed to create load.";
            }*/

            return View("Index", viewModel);
        }

        // Reason this is private is beacuse I will only be using this method on this view
        private List<LoadPlannerModel>? GetAllLoads()
        {
            return _repo.GetAllLoads();
        }

        /*public IActionResult DeleteLoad(int loadID)
        {
            LoadPlannerViewModel viewModel = new LoadPlannerViewModel();
            var currentLoad = _repo.Delete(loadID);

            viewModel.IsActionSuccess = true;
            viewModel.ActionMessage = "Load has been deleted successfully.";

            viewModel.IsActionSuccess = false;
            viewModel.ActionMessage = "Error deleting the load please call the Administrator!";

            return View("Index", viewModel);
        }*/

        

        public IActionResult Update(LoadPlannerModel load)
        {
            LoadPlannerViewModel loadViewModel = new LoadPlannerViewModel();    
            _repo.AssignLoad(load);


            return View("Index", loadViewModel);
        }
    }
}
