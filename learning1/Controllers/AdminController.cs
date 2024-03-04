using learning1.DBEntities.ViewModel;
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

        public IActionResult RenderActivePartialView(int status1, int status2)
        {
            var model = _adminServices.RenderActiveStateData(status1,status2);
            return PartialView("_adminActiveState", model);
        }
        public IActionResult RenderConcludePartialView(int status)
        {
            var model = _adminServices.RenderConcludeStateData(status);
            return PartialView("_adminConcludeState", model);
        }

        public IActionResult RenderToClosePartialView(int status1, int status2, int status3)
        {
            var model = _adminServices.RenderToCloseStateData(status1,status2,status3);
            return PartialView("_adminToCloseState", model);
        }
        public IActionResult RenderUnpaidPartialView(int status)
        {
            var model = _adminServices.RenderUnpaidStateData(status);
            return PartialView("_adminUnpaidState", model);
        }


        [HttpPost]
        public IActionResult CancelCase(AdminDashboardViewModel model)
        {
            _adminServices.GetCancelCaseData(model);
            return RedirectToAction("AdminDashboard");
        }

    }
}
