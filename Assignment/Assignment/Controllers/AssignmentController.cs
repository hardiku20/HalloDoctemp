using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.CustomModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BusinessLogic.Interfaces;

namespace Assignment.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentInterface _assignmentInterface;

        public AssignmentController(IAssignmentInterface assignmentInterface)
        {
            _assignmentInterface = assignmentInterface;
        }

        public IActionResult Index()
        {
            AssignmentCm assignmentCm = new AssignmentCm()
            {
            };
            return View("Index", assignmentCm);
        }



        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }


        public IActionResult RenderPartialView() {
            var model = _assignmentInterface.RenderTable();
            return PartialView("_DashboardPartialView",model);
        
        }

        [HttpPost]
        public IActionResult AddUser(DashboardViewModel model)
        {
            _assignmentInterface.CreateNewUser(model);
            return View("Dashboard");
        }


        public IActionResult Delete(int UserId)
        {
            _assignmentInterface.DeleteById(UserId);
            return RedirectToAction("Dashboard");
        }


      public IActionResult EditUser(DashboardViewModel model)
        {
            _assignmentInterface.EditUserData(model);
            return RedirectToAction("Dashboard");
        }

    }
}
