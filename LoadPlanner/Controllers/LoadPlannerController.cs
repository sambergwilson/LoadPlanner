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

            viewModel.IsActionSuccess = false;
            viewModel.ActionMessage = "Error deleting the load please call the Administrator!";

            return View("Index", viewModel);
        }

        public IActionResult LoadDetails()
        {
            return View();
        }
    }
}
