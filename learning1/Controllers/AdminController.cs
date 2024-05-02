using AspNetCoreHero.ToastNotification.Abstractions;
using learning1.Authentication;
using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Services.IServices;
using learning1.Services.Services;
using learning1.Utils;
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
        private readonly IJWTService _JWTService;
        public AdminController(IAdminServices adminServices,IHttpContextAccessor httpContextAccessor, INotyfService notyf, IJWTService jWTService)
        {
            _adminServices = adminServices;
            _httpcontextAccessor = httpContextAccessor;
            _notyf = notyf;
            _JWTService = jWTService;
        }

      

        public IActionResult PlatformLogin()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult PlatformLogin(LoginViewModel model)
        //{
        //    int AdminId = _adminServices.LoginMethod(model.Email, model.Password);
        //    Admin admin = _adminServices.GetAdminByEmail(model.Email,model.Password);
        //    if(AdminId!= -1)
        //    {
        //        _httpcontextAccessor.HttpContext.Session.SetInt32("Id", AdminId);
        //        _httpcontextAccessor.HttpContext.Session.SetString("userName", admin.FirstName+" "+admin.LastName);
        //        _notyf.Success("Login Successful");
        //        return RedirectToAction("Admindashboard", "Admin");  
        //    }
        //    else
        //    {
        //        _notyf.Error("Login Failed");
        //        return View();
        //    }
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlatformLogin(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
             
                UserInfoViewModel validUser = _adminServices.CheckValidUserWithRole(model.Email, model.Password);
                var JWTToken = _JWTService.GenerateJWTToken(validUser);
                Response.Cookies.Append("jwt", JWTToken);
                SessionUtils.SetLoggedInUser(HttpContext.Session, validUser);
                int AdminId = _adminServices.LoginMethod(model.Email, model.Password);
                Admin admin = _adminServices.GetAdminByEmail(model.Email, model.Password);
                if (AdminId != -1 && admin!=null)
                {
                    _httpcontextAccessor.HttpContext.Session.SetString("userName", admin.FirstName + " " + admin.LastName);
                    _httpcontextAccessor.HttpContext.Session.SetInt32("Id", AdminId);
                    _notyf.Success("Login Successfully");
                    return RedirectToAction("AdminDashboard", "Admin");
                }
                else
                {
                    //_notyf.Error("Invalid credentials ");
                    return View();
                }
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


        [RequiresMenu("Dashboard")]
        [CustomAuthorize("Admin")]
        public IActionResult admindashboard()
        {
            var model = _adminServices.DisplayAdminDashboard();
            return View(model);
        }


        [CustomAuthorize("Admin")]
        public IActionResult ViewCase(int RequestId)
        {
            var model = _adminServices.DisplayViewCase(RequestId);
            return View(model);
        }




        [CustomAuthorize("Admin")]
        public IActionResult ViewNotes(int RequestId)
        {
            ViewNotesViewModel model = _adminServices.GetNotesById(RequestId);
            return View(model);
        }


        [HttpPost]
        public IActionResult ViewNotes(ViewNotesViewModel model)
        {
            _adminServices.SetNotesById(model);
            return RedirectToAction("ViewNotes", "Admin", new { model.RequestId });
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

    
        public IActionResult UnBlockCase(int RequestId)
        {
            _adminServices.UnblockCase(RequestId);
            return RedirectToAction("admindashboard");
        }

        [HttpPost]
        public IActionResult AssignCase(AdminDashboardViewModel model,int RequestId)
        {
            _adminServices.GetAssignCaseData(model,RequestId);
            return RedirectToAction("admindashboard");
        }

        [CustomAuthorize("Admin")]
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


        [CustomAuthorize("Admin")]
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


        [CustomAuthorize("Admin")]
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


        public IActionResult SendAgreement(int RequestId)
        {
            _adminServices.SendAgreementMail(RequestId);
            _notyf.Success("Mail Sent");
            return RedirectToAction("AdminDashboard");
        }


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




        [RequiresMenu("MyProfile")]
        public IActionResult AdminProfile(int AdminId=4)
        {
            var model = _adminServices.GetAdminProfileData(AdminId);
            return View(model);
        }

        [HttpPost]
        public IActionResult MyProfileBillingUpdate(AdminProfileViewModel model)
        {
            _adminServices.UpdateBusinessProfileBilling(model);
            return RedirectToAction("AdminProfile");
        }


        [HttpPost]
        public IActionResult MyProfileAdminInfoUpdate(AdminProfileViewModel model)
        {
            _adminServices.UpdateAdminInformation(model);
            return RedirectToAction("AdminProfile");
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

        [CustomAuthorize("Admin")]
        public IActionResult ProviderLocation()
        {

            ProviderLocationViewModel modal = _adminServices.GetProviderList();
            
            
            return View(modal);

        }










        [CustomAuthorize("Admin")]
        public IActionResult ProviderMenu()
        {

            var modal = _adminServices.GetRegionsforProvider();
            return View(modal);
        }

        public IActionResult GetProviderTable(int regionId)
        {
            var modal = _adminServices.GetProvidersdetails(regionId);
            return PartialView("_ProviderMenuPartialView",modal);
        }




        public IActionResult EditPhysicianAccount()
        {

            var modal = _adminServices.GetRegionsforPhysician();
            return View(modal);
        }

        [CustomAuthorize("Admin")]
        public IActionResult AccountAccess()
        {
            var model = _adminServices.GetAccountAccessTable();
            return View(model);
        }





        public IActionResult CreateRole()
        {
            CreateRoleViewModel model = _adminServices.GetDetailsByRoleId();
            return View(model);
        }

        public IActionResult GetMenuByAccount(int AccountType)
        {
            var MenuList = _adminServices.GetMenus(AccountType);
            CreateRoleViewModel model = new CreateRoleViewModel();
            model.menulist = MenuList;
            return PartialView("_MenuList", model);
        }

        public IActionResult EditRole(int AccountType ,  int RoleId)
        {

            CreateRoleViewModel model = _adminServices.GetEditDetailsByRoleId(AccountType,RoleId);
            return View(model);
        }

        public IActionResult GetMenuByAccountandRole(int AccountType,int RoleId)
        {
            CreateRoleViewModel model = _adminServices.GetEditDetailsByRoleId(AccountType, RoleId);
            return PartialView("_MenuList", model);
        }

        [HttpPost]
        public IActionResult CreateRole(CreateRoleViewModel model)
        {
            _adminServices.CreateRoleByAccount(model);
            _notyf.Success("Role Created Successfully");
            return RedirectToAction("AccountAccess");
        }

        [HttpPost]
        public IActionResult EditRole(CreateRoleViewModel model)
        {
            _adminServices.EditRole(model);
            _notyf.Success("Role Updated");
            return RedirectToAction("AccountAccess");
        }


        public IActionResult DeleteRole(int RoleId)
        {
            _adminServices.DeleteRoleById(RoleId);
            return RedirectToAction("AccountAccess");

        }

        public IActionResult CreateProviderAccount()
        {
            var modal = _adminServices.GetRegionforProvider();
            return View(modal);
        }


        [HttpPost]
        public IActionResult CreateProviderAccount(CreateProviderAccountViewModel model)
        {
            _adminServices.CreateProvider(model);
            _notyf.Success("New Provider Created");
            return RedirectToAction("ProviderMenu");
        }

        public IActionResult CreateAdminAccount()
        {
            var modal = _adminServices.GetRegionforAdmin();
            
            return View(modal);
        }

        [HttpPost]
        public IActionResult CreateAdminAccount(CreateAdminAccountViewModel model)
        {
            _adminServices.CreateAdmin(model);
            _notyf.Success("Admin Created Successfully!!");
            return RedirectToAction("admindashboard");
        }
   

       public IActionResult UserAccess()
        {
            int RoleId = 0;
            UserAccessViewModel model = _adminServices.GetUserAccessdetail(RoleId);
            return View(model);
        }


        public IActionResult GetUserAccessDetails(int RoleId)
        {
            var model = _adminServices.GetUserAccessdetail(RoleId);
            return PartialView("_UserAccessPartialView", model);
        }


        [CustomAuthorize("Admin")]
        public IActionResult Scheduling()
        {
            var model = _adminServices.GetRegionsforShift();
            return View(model);
        }



        public IActionResult CreateNewShift(SchedulingViewModel model)
        {
            _adminServices.CreateNewShift(model);
            return RedirectToAction("Scheduling");
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
        public IActionResult ViewShift(int ShiftDetailId)
        {
            ShiftViewDetailDTO model = _adminServices.GetShiftDetails(ShiftDetailId);
            TempData["CheckAdmin"] = "This is Admin";
            return PartialView("_ViewShiftModal", model);
        }


        public bool ReturnViewShift(int ShiftDetailId)
        {

            try
            {
                int AdminId = (int)_httpcontextAccessor.HttpContext.Session.GetInt32("Id");

                _adminServices.ReturnViewShiftDetail(ShiftDetailId, AdminId);
                return true;
            }
            catch { return false; }

        }
        public bool DeleteViewShift(int ShiftDetailId)
        {
            try
            {
                int AdminId = (int)_httpcontextAccessor.HttpContext.Session.GetInt32("Id");
                _adminServices.DeleteViewShiftDetail(ShiftDetailId, AdminId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditViewShift(ShiftViewDetailDTO ShiftDetail)
        {

            try
            {
                int AdminId = (int)_httpcontextAccessor.HttpContext.Session.GetInt32("Id");
                _adminServices.EditViewShiftDetail(ShiftDetail, AdminId);
                return true;
            }
            catch
            {
                return false;
            }

        }



        [CustomAuthorize("Admin")]
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


        [CustomAuthorize("Admin")]
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

        [CustomAuthorize("Admin")]
        public IActionResult SearchRecord()
        {
            return View();
        }

        public IActionResult RendorSearchHistoryPartialView(string PatientName = null, string ProviderName =null, string Email = null,string PhoneNumber = null)
        {
            var model = _adminServices.GetSearchData(PatientName,ProviderName,Email,PhoneNumber);
            return PartialView("_SearchRecordPartialView",model);

        }


        [CustomAuthorize("Admin")]
        public IActionResult EmailLogs()
        {
            return View();
        }

        [CustomAuthorize("Admin")]
        public IActionResult SMSLogs()
        {
            return View();
        }

        [CustomAuthorize("Admin")]
        public IActionResult BlockHistory()
        {
            return View();
        }

        public IActionResult RendorBlockHistoryPartialView(string Name = null , string date = null ,string Email = null , string phoneNumber = null)
        {
            var model = _adminServices.GetBlockRecords(Name, date, Email, phoneNumber);
            return PartialView("_BlockRecordPartialView",model);
        }

        [CustomAuthorize("Admin")]
        public IActionResult CancelHistory()
        {
            return View();
        }

        public List<Physician> GetPhysicianByRegionId(int regionId)
        {
            List<Physician> PhysicianList = _adminServices.GetPhysiciansByRegion(regionId);
            return PhysicianList;
        }


        public void SaveProviderInfo(List<int> Idlist)
        {
            _adminServices.SaveNotifications(Idlist);
        }



      
        public IActionResult CloseCase(int requestId)
        {
            CloseCaseViewModel modal = _adminServices.GetCloseCase(requestId);
            return View(modal);
        }

        public IActionResult ClosecasePost(int requestId, CloseCaseViewModel modal)
        {
            modal.ReqId = requestId;
            _adminServices.SetCloseCase(modal);
            return RedirectToAction("CloseCase", "Admin", new { requestId = requestId });
        }

        public IActionResult CloseCaseFinal(int requestId)
        {
            bool response = _adminServices.UpdateRequest(requestId);
            if (response) { _notyf.Success("Case has been closed"); }
            else { _notyf.Error("somthing Went wrong"); }
            return RedirectToAction("AdminDashboard", "Admin");
        }


























        public IActionResult Logout()
        {
            _httpcontextAccessor.HttpContext.Session.Clear();
            Response.Cookies.Delete("jwt");
            //_notyf.Success("Logged Out");
            return RedirectToAction("PlatformLogin", "Admin");
        }

    

    }
}
