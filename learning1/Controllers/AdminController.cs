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

        public IActionResult RenderNewPartialView(int status)
        {
            var model = _adminServices.RenderNewStateData(status);
            return PartialView("_adminNewState", model);
        }

        public IActionResult RenderPendingPartialView(int status)
        {
            var model = _adminServices.RenderPendingStateData(status);
            return PartialView("_adminPendingState", model);
        }

        public IActionResult RenderActivePartialView(int status)
        {
            var model = _adminServices.RenderActiveStateData(status);
            return PartialView("_adminActiveState", model);
        }
        public IActionResult RenderConcludePartialView(int status)
        {
            var model = _adminServices.RenderConcludeStateData(status);
            return PartialView("_adminConcludeState", model);
        }

        public IActionResult RenderToClosePartialView(int status)
        {
            var model = _adminServices.RenderToCloseStateData(status);
            return PartialView("_adminToCloseState", model);
        }
        public IActionResult RenderUnpaidPartialView(int status)
        {
            var model = _adminServices.RenderUnpaidStateData(status);
            return PartialView("_adminUnpaidState", model);
        }

    }
}
