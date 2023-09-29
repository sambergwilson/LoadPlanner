using LoadPlanner.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoadPlanner.Controllers
{
    public class LoadPlannerController : Controller
    {
        private readonly LoadPlannerRepository _context;
        public IActionResult Index()
        {
            return View();
        }
    }
}
