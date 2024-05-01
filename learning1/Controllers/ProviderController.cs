using AspNetCoreHero.ToastNotification.Abstractions;
using learning1.Authentication;
using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using learning1.Services.Services;
using learning1.Utils;
using Microsoft.AspNetCore.Mvc;

namespace learning1.Controllers
{
    public class ProviderController : Controller
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProviderServices _providerServices;
        private readonly INotyfService _notyf;
        private readonly IJWTService _JWTService;

        public ProviderController(IHttpContextAccessor contextAccessor, IProviderServices providerServices,INotyfService notyf, IJWTService jWTService)
        {
            _contextAccessor = contextAccessor;
            _providerServices = providerServices;
            _notyf = notyf;
            _JWTService = jWTService;
        }



        public IActionResult Index()
        {
            return View();
        }



        [CustomAuthorize("Physician")]
        public IActionResult ProviderDashboard(int PhysicianId = 21)
        {
            var model = _providerServices.DisplayProviderDashboard(PhysicianId);
            return View(model);
        }

        public IActionResult RenderNewPartialView(int Status,int physicianId = 21, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {

            var model = _providerServices.RenderNewStateData(Status, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerNewState", model);
        }



        public IActionResult RenderPendingPartialView(int Status, int physicianId = 21, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _providerServices.RenderPendingStateData(Status, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerPendingState", model);
        }

        public IActionResult RenderActivePartialView(int status1,  int status2, int physicianId = 21, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _providerServices.RenderActiveStateData(status1, status2, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerActiveState", model);
        }
        public IActionResult RenderConcludePartialView(int Status, int physicianId = 21, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _providerServices.RenderConcludeStateData(Status, physicianId, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_providerConcludeState", model);
        }


        [CustomAuthorize("Physician")]
        public IActionResult ViewCase(int RequestId)
        {
            var model = _providerServices.DisplayViewCase(RequestId);
            return View(model);
        }


        public IActionResult CreateRequest()
        {
            return View();
        }

     
        public IActionResult AcceptCase(int requestId)
        {
            //var loginUserId = GetLoginId();
            _providerServices.acceptCase(requestId);
            _notyf.Success("Request Successfully Accepted !!");
            return RedirectToAction("ProviderDashboard");
        }




        [CustomAuthorize("Physician")]
        public IActionResult ViewUpload(int requestId)
        {
            var model = _providerServices.GetviewUploads(requestId);
            return View(model);
        }


        [HttpPost]
        public IActionResult ViewUpload(ViewUploadViewModel model, int requestId)
        {
            if (model.formFile != null)
            {
                _providerServices.InsertviewUploads(model, requestId);
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



        [CustomAuthorize("Physician")]
        public IActionResult TransferCase(ProviderDashboardViewModel model, int RequestId)
        {
            _providerServices.GetTransferCaseData(model, RequestId);
            return RedirectToAction("providerdashboard");
        }

        [CustomAuthorize("Physician")]
        public IActionResult SendOrders()
        {
            var model = _providerServices.GetOrderdetails();
            return View(model);
        }


      
        public List<string> GetBusinessByProfessionName(string ProfessionName)
        {
            var BusinessList = _providerServices.GetBusinessByProfession(ProfessionName);
            return BusinessList;

        }

        public SendOrderViewModel GetOrderdetailByBusiness(string BusinessName)
        {
            var model = _providerServices.GetDetailsByBusiness(BusinessName);
            return model;
        }


        [HttpPost]
        public IActionResult SendOrders(SendOrderViewModel model)
        {

            _providerServices.InsertOrderDetails(model);
            _notyf.Success("Order Placed");
            return RedirectToAction("ProviderDashboard");
        }


        [CustomAuthorize("Physician")]
        public IActionResult ProviderProfile(int PhysicianId = 21)
        {

            var model = _providerServices.GetProviderProfileData(PhysicianId);
            return View(model);    
        }



        [CustomAuthorize("Physician")]
        public IActionResult ViewNotes(int RequestId)
        {
            ViewNotesViewModel model = _providerServices.GetNotesById(RequestId);
            return View(model);
        }

        [HttpPost]
        public IActionResult ViewNotes(ViewNotesViewModel model)
        {
            _providerServices.SetNotesById(model);
            return RedirectToAction("ViewNotes", "Provider", new {model.RequestId });
        }




        public IActionResult PlatformLogin()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlatformLogin(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                UserInfoViewModel validUser = _providerServices.CheckValidUserWithRole(model.Email, model.Password);
                var JWTToken = _JWTService.GenerateJWTToken(validUser);
                Response.Cookies.Append("jwt", JWTToken);
                SessionUtils.SetLoggedInUser(HttpContext.Session, validUser);




                int physicianId = _providerServices.LoginMethod(model.Email, model.Password);
                Physician physician = _providerServices.GetPhysicianByEmail(model.Email, model.Password);
                if (physicianId != -1)
                {
                    _contextAccessor.HttpContext.Session.SetString("userName", physician.FirstName + " " + physician.LastName);
                    _contextAccessor.HttpContext.Session.SetInt32("Id", physicianId);
                    _notyf.Success("Login Successfully");
                    return RedirectToAction("ProviderDashboard", "Provider");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }




        [CustomAuthorize("Physician")]
        public IActionResult ProviderScheduling()
        {
            int PhysicianId = 21;
            var data = _providerServices.GetPhysicianRegionList(PhysicianId);
            ProviderSchedulingViewModel model = new()
            {
                RegionList = data,
                PhysicianId = PhysicianId,
            };
            return View(model);
        }

        public IActionResult GetScheduleData(string RegionId = "0")
        {
            int PhysicianId = 21;
            string[] color = { "#edacd2", "#a5cfa6" };
            List<ShiftDetail> shiftDetails = _providerServices.GetProviderScheduleData(PhysicianId, int.Parse(RegionId));
            string Name = "Static Physiciain";
            string UserName = _contextAccessor.HttpContext.Session.GetString("UserName");
            if (!string.IsNullOrEmpty(UserName))
            {
                Name = UserName;
            }
            List<ShiftDTO> list = shiftDetails.Select(s => new ShiftDTO
            {
                resourceId = s.Shift.PhysicianId,
                Id = s.ShiftDetailId,
                title = Name,
                start = s.ShiftDate.ToString("yyyy-MM-dd") + s.StartTime.ToString("THH:mm:ss"),
                end = s.ShiftDate.ToString("yyyy-MM-dd") + s.EndTime.ToString("THH:mm:ss"),
                color = color[s.Status - 1]
            }).ToList();

            return Json(list);
        }

        public IActionResult SetCreateNewShiftData(ProviderSchedulingViewModel model)
        {
            int PhysicianId = 21;
            model.PhysicianId = PhysicianId;
            bool res = _providerServices.SetCreateNewShiftData(model);
            if (res) { _notyf.Success("shift created successfully"); }
            else { _notyf.Error("Something Went Wrong Shift is not created"); }
            return RedirectToAction("ProviderScheduling");
        }






        public IActionResult Logout()
        {
            _contextAccessor.HttpContext.Session.Clear();
            Response.Cookies.Delete("jwt");
            //_notyf.Success("Logged Out");
            return RedirectToAction("PlatformLogin", "Provider");
        }


        [HttpPost]
        public IActionResult Housecall(int requestId)
        {
            _providerServices.clickHousecall(requestId);
            return RedirectToAction("ProviderDashboard");
        }


        public IActionResult Consult(int requestId)
        {

            _providerServices.clickConsult(requestId);
            return RedirectToAction("ProviderDashboard");


            //    RedirectToAction("_providerConcludeState", new
            //{
            //    status = 6,
            //});
        }

        public IActionResult ConcludeCare(int RequestId)
        {
            CloseCaseViewModel model = _providerServices.GetConcludeCare(RequestId);
            return View(model);
        }

        public IActionResult ConcludeCareUpload(CloseCaseViewModel modal)
        {
            if (modal.FileforConcludeCare != null)
            {
                bool res = _providerServices.UploadConcludeDocument(modal.FileforConcludeCare, modal.ReqId);
                if (res) { _notyf.Success("Document uploaded successfully"); }
                else { _notyf.Error("something went wrong document is not uploaded"); }
            }
            else
            {
                _notyf.Error("Please select document to upload");
            }
            return RedirectToAction("ConcludeCare", "Provider", new { RequestId = modal.ReqId });
        }


        public IActionResult ConcludCareFinal(int id, CloseCaseViewModel modal)
        {
            bool response = _providerServices.ConcludeCare(id, modal);
            if (response) { _notyf.Success("Case has been closed"); }
            else { _notyf.Error("somthing Went wrong"); }
            return RedirectToAction("ProviderDashboard", "Provider");
        }


        public IActionResult EncounterForm()
        {
            return View();
        }


        public IActionResult SendAgreementMail(int RequestId)
        {
            _providerServices.SendAgreement(RequestId);
            return RedirectToAction("ProviderDashboard");
        }

    }
}
