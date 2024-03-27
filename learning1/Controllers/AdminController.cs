using AspNetCoreHero.ToastNotification.Abstractions;
using learning1.DBEntities.ViewModel;
using learning1.Services.IServices;
using learning1.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace learning1.Controllers
{
    public class AdminController : Controller
    {

        private readonly IHttpContextAccessor _httpcontextAccessor;
        private readonly IAdminServices _adminServices;
        private readonly INotyfService _notyf;

        public AdminController(IAdminServices adminServices,IHttpContextAccessor httpContextAccessor, INotyfService notyf)
        {
            _adminServices = adminServices;
            _httpcontextAccessor = httpContextAccessor;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PlatformLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlatformLogin(LoginViewModel model)
        {
            int userId = _adminServices.LoginMethod(model.Email, model.Password);

            if(userId!= -1)
            {
                _httpcontextAccessor.HttpContext.Session.SetInt32("Id", userId);
                _notyf.Success("Login Successful");
                return RedirectToAction("Admindashboard", "Admin");  
            }
            else
            {
                _notyf.Error("Login Failed");
                return View();
            }
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


   


        public IActionResult ViewNotes(int RequestId)
        {
            var model = _adminServices.GetViewNotesData(RequestId);
            return View(model);
        }


        [HttpPost]
        public IActionResult ViewNotes(ViewNotesViewModel model, int RequestId)
        {
            _adminServices.SetViewNotesData(model, RequestId);
            return RedirectToAction("ViewNotes",model);
        }

        public IActionResult RenderNewPartialView(int Status ,int Page = 1, int PageSize = 4, string patientName = null,RequestType requestType=(RequestType)5)
        {
            
            var model = _adminServices.RenderNewStateData(Status, Page, PageSize, patientName,requestType);
            return PartialView("_adminNewState", model);
        }



        public IActionResult RenderPendingPartialView(int Status, int Page = 1, int PageSize = 4, string patientName = null)
        {
            var model = _adminServices.RenderPendingStateData(Status, Page, PageSize, patientName);
            return PartialView("_adminPendingState", model);
        }

        public IActionResult RenderActivePartialView(int status1, int status2,int Page = 1, int PageSize = 4, string patientName = null)
        {
            var model = _adminServices.RenderActiveStateData(status1,status2,Page,PageSize,patientName);
            return PartialView("_adminActiveState", model);
        }
        public IActionResult RenderConcludePartialView(int Status, int Page = 1, int PageSize = 4, string patientName = null)
        {
            var model = _adminServices.RenderConcludeStateData(Status, Page, PageSize, patientName);
            return PartialView("_adminConcludeState", model);
        }

        public IActionResult RenderToClosePartialView(int status1, int status2, int status3,int Page = 1, int PageSize = 4, string patientName = null)
        {
            var model = _adminServices.RenderToCloseStateData(status1,status2,status3, Page, PageSize, patientName);
            return PartialView("_adminToCloseState", model);
        }
        public IActionResult RenderUnpaidPartialView(int Status, int Page = 1, int PageSize = 4, string patientName = null)
        {
            var model = _adminServices.RenderUnpaidStateData(Status, Page, PageSize, patientName);
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

        [HttpPost]
        public IActionResult BlockCase(AdminDashboardViewModel model)
        {
            _adminServices.GetBlockCaseData(model);
            return RedirectToAction("admindashboard");
        }

        [HttpPost]
        public IActionResult AssignCase(AdminDashboardViewModel model,int RequestId)
        {
            _adminServices.GetAssignCaseData(model,RequestId);
            return RedirectToAction("admindashboard");
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
            _notyf.Success("Success Notification");
            return RedirectToAction("admindashboard");
        }


        [HttpPost]
        public IActionResult ClearCase(AdminDashboardViewModel model)
        {
            _adminServices.IsClearCase(model);
            return RedirectToAction("admindashboard");
        }

        public List<string> GetAvailablePhysicianByRegionName(string regionName)
        {
            var PhysicianList = _adminServices.GetAvailablePhysicianByRegion(regionName);
            return PhysicianList;
        }

        public IActionResult TransferCase(AdminDashboardViewModel model,int RequestId)
        {
            _adminServices.GetTransferCaseData(model, RequestId);
            return RedirectToAction("admindashboard");
        }


        public IActionResult CreateRequest()
        {
            return View();
        }

        public IActionResult EncounterForm(int RequestId)
        {
            var model = _adminServices.GetEncounterformData(RequestId);
            return View(model);
        }

        
        //public IActionResult SendAgreementMail(string email, int reqId)
        //{
        //    _adminServices.SendAgreementData(email, reqId);
        //    return RedirectToAction("admindashboard");
        //}



        //[HttpPost]
        //public IActionResult SendAgreementMail(AdminDashboardViewModel model, int RequestId)
        //{
        //    _adminServices.SendAgreementData(model, RequestId);
        //    return RedirectToAction("admindashboard");
        //}

        //[HttpPost]
        //public IActionResult SendLink(AdminDashboardViewModel model)
        //{
        //    _adminServices.SendLinkData(model);
        //    return RedirectToAction("admindashboard");
        //}

        

        public IActionResult CloseCase()
        {
            return View();
        }


        public IActionResult AdminProfile()
        {
            return View();
        }



        public FileStreamResult ExportListUsingEPPlus()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license

            // Fetch data and create Excel content
            AdminDashboardViewModel model = _adminServices.ListToExportAllData();
            var data = model.ExportViewModel?.ToList();
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells[1, 1].LoadFromCollection(data, true);

            var memoryStream = new MemoryStream();

            // Save Excel content to MemoryStream
            excel.SaveAs(memoryStream);

            // Rewind stream before returning as a file
            memoryStream.Position = 0;
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExportedData.xlsx");
            // MemoryStream disposed here
        }



        public IActionResult SendAgreementMail(int RequestId)
        {
            _adminServices.SendAgreement(RequestId);
            return RedirectToAction("admindashboard");
        }


        [HttpPost]
        public IActionResult Sendlink(AdminDashboardViewModel model)
        {
            _adminServices.SendlinktoPatient(model);
            return RedirectToAction("admindashboard");
        }


        [HttpPost]
        public IActionResult CreateRequest(CreateRequestViewModel model)
        {
            _adminServices.CreatePatientRequest(model);
            return RedirectToAction("admindashboard");
        }


        public IActionResult ProviderMenu()
        {
            return View();
        }


        public IActionResult EditPhysicianAccount()
        {
            return View();
        }


        public IActionResult AccountAccess()
        {
            return View();
        }


        public IActionResult CreateRole()
        {
            return View();
        }


        public IActionResult CreateProviderAccount()
        {
            return View();
        }

        public IActionResult CreateAdminAccount()
        {
            return View();
        }


    }
}
