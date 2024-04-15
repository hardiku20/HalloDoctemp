using AspNetCoreHero.ToastNotification.Abstractions;
using learning1.DBEntities.Models;
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
            int AdminId = _adminServices.LoginMethod(model.Email, model.Password);
            if(AdminId!= -1)
            {
                _httpcontextAccessor.HttpContext.Session.SetInt32("Id", AdminId);
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

        public IActionResult RenderNewPartialView(int Status ,int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType=(learning1.DBEntities.ViewModel.RequestType)5)
        {
            
            var model = _adminServices.RenderNewStateData(Status, Page, PageSize, patientName, regionName,requestType);
            return PartialView("_adminNewState", model);
        }



        public IActionResult RenderPendingPartialView(int Status, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _adminServices.RenderPendingStateData(Status, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_adminPendingState", model);
        }

        public IActionResult RenderActivePartialView(int status1, int status2, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _adminServices.RenderActiveStateData(status1,status2, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_adminActiveState", model);
        }
        public IActionResult RenderConcludePartialView(int Status, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _adminServices.RenderConcludeStateData(Status, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_adminConcludeState", model);
        }

        public IActionResult RenderToClosePartialView(int status1, int status2, int status3, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _adminServices.RenderToCloseStateData(status1,status2,status3, Page, PageSize, patientName, regionName, requestType);
            return PartialView("_adminToCloseState", model);
        }
        public IActionResult RenderUnpaidPartialView(int Status, int Page = 1, int PageSize = 4, string patientName = null, string regionName = null, learning1.DBEntities.ViewModel.RequestType requestType = (learning1.DBEntities.ViewModel.RequestType)5)
        {
            var model = _adminServices.RenderUnpaidStateData(Status, Page, PageSize, patientName, regionName, requestType);
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
            _notyf.Success("Order Placed");
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


        public IActionResult AdminProfile(int AdminId=1)
        {
            var model = _adminServices.GetAdminProfileData(AdminId);
            return View(model);
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
            var model = _adminServices.GetAccountAccessTable();
            return View(model);
        }





        public IActionResult CreateRole(int RoleId)
        {
            CreateRoleViewModel model = _adminServices.GetDetailsByRoleId(RoleId);
            return View(model);
        }


        public IActionResult EditRole(int RoleId)
        {
            CreateRoleViewModel model = _adminServices.GetDetailsByRoleId(RoleId);  
            return PartialView("_MenuList", model);
        }

        public IActionResult GetMenuByAccount(int AccountType) {
            var MenuList = _adminServices.GetMenus(AccountType);
            CreateRoleViewModel model= new CreateRoleViewModel();
            model.menulist= MenuList;
            return PartialView("_MenuList",model);
        }




        public IActionResult CreateProviderAccount()
        {
            return View();
        }


        public IActionResult CreateAdminAccount()
        {
            var modal = _adminServices.GetRegionforAdmin();
            return View(modal);
        }



        
        //public List<string> GetMenuByAccount(int AccountType)
        //{
        //    var Menulist = _adminServices.GetMenuList(AccountType);
        //    return Menulist;
        //}


        


        [HttpPost]
        public IActionResult CreateRole(CreateRoleViewModel model)
        {
            _adminServices.CreateRoleByAccount(model);
            _notyf.Success("Role Created Successfully");
            return RedirectToAction("AccountAccess");
        }

        //public IActionResult CreateRole(int RoleId)
        //{
        //    var model = _adminServices.EditRoleById(RoleId);
        //    return View(model);
        //}

       public IActionResult UserAccess()
        {
            return View();
        }


        public IActionResult GetUserAccessDetails()
        {
            var model = _adminServices.GetUserAccessdetail();
            return PartialView("_UserAccessPartialView", model);
        }

        public IActionResult DeleteRole(int RoleId)
        {
            _adminServices.DeleteRoleById(RoleId);
            return RedirectToAction("AccountAccess");

        }

        public IActionResult Scheduling(SchedulingViewModel model)
        {

            return View(model);
        }






        public IActionResult GetProviderDetailsForSchedule(int RegionId)
        {
            List<ProviderMenuDetailsViewModel> model = _adminServices.GetPhysicianDataByRegion(RegionId);

            List<ProviderDTO> list = model.Select(x => new ProviderDTO
            {
                Id = x.PhysicianId,
                title = x.Name ?? "",
                //imageUrl = "https://api.slingacademy.com/public/sample-photos/" + new Random().Next(0, 100) + ".jpeg"
            }).ToList();
            return Json(list);
        }

        public IActionResult GetScheduleData()
        {
            string[] color = { "#edacd2", "#a5cfa6" };
            List<ShiftDetail> shiftDetails = _adminServices.GetScheduleData();

            List<ShiftDTO> list = shiftDetails.Select(s => new ShiftDTO
            {
                resourceId = s.Shift.PhysicianId,
                Id = s.ShiftDetailId,
                title = "Event " + s.ShiftDetailId,
                start = s.ShiftDate.ToString("yyyy-MM-dd") + s.StartTime.ToString("THH:mm:ss"),
                end = s.ShiftDate.ToString("yyyy-MM-dd") + s.EndTime.ToString("THH:mm:ss"),
                color = color[s.Status - 1]
            }).ToList();

            return Json(list);
        }

        public List<Region> GetRegions()
        {
            var regionsData = _adminServices.getRegionTableData();
            return regionsData;
        }


        public IActionResult Vendors(int ProfessionId, string VendorName = null)
        {
            var model = _adminServices.GetVendorsDetails(ProfessionId, VendorName);
            return View(model);
        }


        public IActionResult RenderVendorTable(int ProfessionId, string VendorName = null)
        {
            var model = _adminServices.GetVendorsDetails(ProfessionId,VendorName);
            return View("_VendorPartialView",model);
        }



        public IActionResult AddBusiness()
        {
            var model = _adminServices.GetProfession();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddBusiness(AddBusinessViewModal modal)
        {
            _adminServices.AddNewBusiness(modal);
            _notyf.Success("Vendor Added");
            return RedirectToAction("Vendors");
        }


        public IActionResult EditBusiness(int VendorId)
        {
            var model = _adminServices.GetBusinessByVendorId(VendorId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditBusiness(AddBusinessViewModal modal)
        {
            _adminServices.UpdateBusiness(modal);
            _notyf.Success("Edit Successful!!");
            return RedirectToAction("Vendors");
        }

        [HttpPost]
        public IActionResult DeleteBusiness(int VendorId)
        {
            _adminServices.DeleteBusinessByVendor(VendorId);
            _notyf.Success("Record Deleted");
            return RedirectToAction("Vendors");
        }


        public IActionResult PatientHistory()
        {
            return View();
        }


        public IActionResult RendorPatientHistoryPartialView(string firstname = null, string lastname = null , string email = null, string phoneNumber = null)
        {
            var model = _adminServices.GetPatientHistory(firstname, lastname, email, phoneNumber);
            return PartialView("_PatientHistoryPartialView",model);
        }

        public IActionResult PatientRecordExplore(int UserId)
        {
            var model = _adminServices.GetPatientExplore(UserId);
            return View(model);
        }


        public IActionResult SearchRecord()
        {
            return View();
        }

        public IActionResult RendorSearchHistoryPartialView(string PatientName = null, string ProviderName =null, string Email = null,string PhoneNumber = null)
        {
            var model = _adminServices.GetSearchData(PatientName,ProviderName,Email,PhoneNumber);
            return PartialView("_SearchRecordPartialView",model);

        }

        public IActionResult EmailLogs()
        {
            return View();
        }


        public IActionResult SMSLogs()
        {
            return View();
        }


        public IActionResult BlockHistory()
        {
            return View();
        }

        public IActionResult RendorBlockHistoryPartialView(string Name = null , string date = null ,string Email = null , string phoneNumber = null)
        {
            var model = _adminServices.GetBlockRecords(Name, date, Email, phoneNumber);
            return PartialView("_BlockRecordPartialView",model);
        }

        public IActionResult CancelHistory()
        {
            return View();
        }

    }
}
