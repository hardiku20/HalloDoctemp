using learning1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace learning1.Controllers
{
    public class AdminController : Controller
    {


        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult admindashboard()
        {
            var model = _adminServices.DisplayAdminDashboard();
            return View(model);
        }

        public IActionResult ViewCase(int RequestId)
        {
            var model = _adminServices.DisplayViewCase(RequestId);
            return View(model);
        }


        public IActionResult ViewNotes()
        {
            return View();
        }

    }
}
