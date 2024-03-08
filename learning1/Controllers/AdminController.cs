using learning1.DBEntities.ViewModel;
using learning1.Services.IServices;
using learning1.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace learning1.Controllers
{
    public class AdminController : Controller
    {

        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices,IHttpContextAccessor httpContextAccessor)
        {
            _adminServices = adminServices;
            _httpcontextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PlatformLogin()
        {
            return View();
        }

        public IActionResult ForgotPassword()
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


        public List<string> GetPhysicianByRegionName(string regionName)
        {
            var PhysicianList = _adminServices.GetPhysicianByRegion(regionName);
            return PhysicianList;
        }


        public IActionResult BlockCase(AdminDashboardViewModel model)
        {
            _adminServices.GetBlockCaseData(model);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult ViewUpload(int requestId)
        {
            
            var model = _adminServices.GetviewUploads(requestId);
            return View(model);
        }


        [HttpPost]
        public IActionResult ViewUpload(ViewUploadViewModel model, int requestId)
        {
            if (model.formFile != null)
            {
                _adminServices.InsertviewUploads(model, requestId);
                return RedirectToAction("ViewUpload", model);
            }
            return View(model);
        }


        public IActionResult download_file(string filename)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData("Files/PatientDocs/" + filename);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            return File(content, contentType, filename);
        }



        public IActionResult SendOrders()
        {
           var model= _adminServices.GetOrderdetails();
           return View(model);
        }

        public List<string> GetBusinessByProfessionName(string ProfessionName)
        {
            var BusinessList = _adminServices.GetBusinessByProfession(ProfessionName);
            return BusinessList;

        }

        public SendOrderViewModel GetOrderdetailByBusiness(string BusinessName)
        {
            var model = _adminServices.GetDetailsByBusiness(BusinessName);
            return model;
        }


        [HttpPost]
        public IActionResult SendOrders(SendOrderViewModel model)
        {

            _adminServices.InsertOrderDetails(model);
            return RedirectToAction("admindashboard");
        }


    }
}
