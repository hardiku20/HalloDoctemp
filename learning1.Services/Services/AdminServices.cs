using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepo _adminRepo;
        public AdminServices(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public AdminDashboardViewModel DisplayAdminDashboard()
        {
            var Casetags = _adminRepo.DisplayCasetags();
            var Regions = _adminRepo.DisplayRegions();
            var Count = _adminRepo.SetCount();
            var temp = _adminRepo.DisplayAdminDashboardRepo().
                Select(x => new AdminTableViewModel
                {
                    RequestId = x.RequestId,
                    RequestedDate = x.CreatedDate.ToString(),
                    Phone = x.PhoneNumber,
                    Name = x.RequestClients.Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                    Address = x.RequestClients.Select(x => x.Address).FirstOrDefault(),
                    Requester = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                //TableViewModel = temp,
                CancellationReason = Casetags,
                Region = Regions, 
                RequestCount = Count,
            };
            return model;
        }

        public ViewCaseViewModel DisplayViewCase(int requestId)
        {
            var model = _adminRepo.DisplayViewCaseRepo(requestId);
            return model;
        }

        public void SendAgreement(int requestId)
        {
            _adminRepo.Mails(requestId);    
        }

        public void GetAssignCaseData(AdminDashboardViewModel model, int requestId)
        {
            _adminRepo.AssignCaseRepo(model, requestId);
        }

        public List<string> GetAvailablePhysicianByRegion(string regionName)
        {
            var physicianName = _adminRepo.GetAvailablePhysicianByRegionName(regionName);
            return physicianName;
        }

        public void GetBlockCaseData(AdminDashboardViewModel model)
        {
            _adminRepo.BlockCaseRepo(model);
        }

        public List<string> GetBusinessByProfession(string professionName)
        {
            var BusinessName = _adminRepo.GetBusinessByProfessionName(professionName);
            return BusinessName;
        }

        public void GetCancelCaseData(AdminDashboardViewModel model)
        {
            _adminRepo.CancelCaseRepo(model);
        }

        public SendOrderViewModel GetDetailsByBusiness(string businessName)
        {
            var Orderdetails = _adminRepo.GetOrder(businessName);
            return Orderdetails;
        }

        public SendOrderViewModel GetOrderdetails()
        {
            var Profession =_adminRepo.DisplayProfession();
            SendOrderViewModel model = new SendOrderViewModel()
            {
                Profession = Profession,
            };
            return model;
        }

        //public void GetOrderdetails(SendOrderViewModel model)
        //{
        //    _adminRepo.OrderdetailsRepo(model);
        //}

        public List<string> GetPhysicianByRegion(string regionName)
        {
            var physicianName = _adminRepo.GetPhysicianByRegionName(regionName);
            return physicianName;
        }

        //public void GetSendAgreementData(AdminDashboardViewModel model, int requestId)
        //{
        //    _adminRepo.SendAgreementRepo(model, requestId);
        //}

        public void GetTransferCaseData(AdminDashboardViewModel model, int requestId)
        {
            _adminRepo.TransferCaseRepo(model, requestId);
        }

      

        public ViewUploadViewModel GetviewUploads(int requestId)
        {
           var model= _adminRepo.FetchViewUploads(requestId);
           return model;
        }

        public void InsertOrderDetails(SendOrderViewModel model)
        {
            _adminRepo.OrderDetailRepo(model);
        }

        public void InsertviewUploads(ViewUploadViewModel model, int requestId)
        {
            _adminRepo.Uploaddocuments(model, requestId);
        }

        public void IsClearCase(AdminDashboardViewModel model)
        {
            _adminRepo.ClearCaseRepo(model);
        }

        public AdminDashboardViewModel ListToExportAllData()
        {
            var model = _adminRepo.ListToExportAllData();
            return model;
        }



    
        public AdminDashboardViewModel RenderActiveStateData(int status1, int status2 , int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderToActiveState(status1, status2, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderConcludeStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderConcludeState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderNewStateData(int status,int page,int pageSize,string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderNewState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderPendingStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderPendingState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderToCloseStateData(int status1,int status2, int status3, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderToCloseState(status1 , status2,status3, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidStateData(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderUnpaidState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

   

        public EncounterFormViewModel GetEncounterformData(int requestId)
        {
            var model = _adminRepo.GetEncounterRepo(requestId);
            return model;
        }

        public int LoginMethod(string email, string password)
        {
            int AdminId= _adminRepo.LoginMethodRepo(email, password);
            return AdminId;
        }

        public void SendlinktoPatient(AdminDashboardViewModel model)
        {
            _adminRepo.SendlinkMail(model);
        }

        public void CreatePatientRequest(CreateRequestViewModel model)
        {
            _adminRepo.CreateRequestRepo(model);
        }

        public CreateAdminAccountViewModel GetRegionforAdmin()
        {
            var regions = _adminRepo.GetRegionTable();
            CreateAdminAccountViewModel model = new CreateAdminAccountViewModel()
            {
                Region = regions,
            };
            return model;
        }

        public AdminProfileViewModel GetAdminProfileData(int AdminId)
        {
            var model = _adminRepo.GetAdminProfileRepo(AdminId);
            return model;


        }

        public List<Menu> GetMenus(int accountType)
        {
            var Menus = _adminRepo.GetMenuRepo(accountType);
            return Menus;
        }

        public void CreateRoleByAccount(CreateRoleViewModel model)
        {
            _adminRepo.CreateRoleRepo(model);
        }

        public AccountAccessViewModel GetAccountAccessTable()
        {
            var model = _adminRepo.GetAccountAccessRepo();
            return model;
        }

        public CreateRoleViewModel GetDetailsByRoleId(int roleId)
        {
            return _adminRepo.GetRoleDetailsRepo(roleId);
        }

        public void DeleteRoleById(int roleId)
        {
            _adminRepo.DeleteRoleRepo(roleId);
        }

        public List<ShiftDetail> GetScheduleData()
        {
            return _adminRepo.GetScheduleData();
        }

        public List<Region> getRegionTableData()
        {
            return _adminRepo.GetRegionTable();
        }

        public List<ProviderMenuDetailsViewModel> GetPhysicianDataByRegion(int regionId)
        {
            var tableData = _adminRepo.ProviderMenuTableDetails(regionId);


            return tableData;
        }

        public AddBusinessViewModal GetProfession()
        {
            var Profession = _adminRepo.DisplayProfessionlist();
            AddBusinessViewModal model = new AddBusinessViewModal()
            {
                ProfessionalTypes = Profession,
            };
            return model;
        }

        public void AddNewBusiness(AddBusinessViewModal modal)
        {
            _adminRepo.AddBusinessRepo(modal);
        }

      

        public AddBusinessViewModal GetBusinessByVendorId(int vendorId)
        {
            var model = _adminRepo.GetBusinessRepo(vendorId);
            return model;
        }

        public void UpdateBusiness(AddBusinessViewModal modal)
        {
            _adminRepo.UpdateBusinessRepo(modal);
        }

        public void DeleteBusinessByVendor(int vendorId)
        {
            _adminRepo.DeleteBusinessRepo(vendorId);
        }

        public VendorViewModel GetVendorsDetails(int professionId, string vendorName)
        {
            var model = _adminRepo.GetVendorRepo(professionId,vendorName);
            return model;
        }

        public RecordsViewModel GetPatientHistory(string firstname,string lastname, string email, string phonenumber)
        {
            var model = _adminRepo.PatientHistoryRepo(firstname,lastname,email,phonenumber);
            return model;
        }

        public RecordsViewModel GetPatientExplore(int userId)
        {
            var model = _adminRepo.PatientExploreRepo(userId);
            return model;
        }

        public RecordsViewModel GetSearchData(string patientName, string providerName, string email, string phoneNumber)
        {
            var model = _adminRepo.SearchDataRepo(patientName, providerName , email ,phoneNumber);
            return model;
        }

        public UserAccessViewModel GetUserAccessdetail(int RoleId)
        {
            var model = _adminRepo.GetUserAccessRepo(RoleId);  
            return model;

        }

        public RecordsViewModel GetBlockRecords(string name, string date, string email, string phoneNumber)
        {
            var model = _adminRepo.BlockDataRepo(name,date,email,phoneNumber);
            return model;
        }

        public CreateRoleViewModel GetDetailsByRoleId()
        {
            return _adminRepo.GetRoleDetailsRepo();
        }

        public CreateProviderAccountViewModel GetRegionforProvider()
        {
            var regions = _adminRepo.GetRegionTable();
            CreateProviderAccountViewModel model = new CreateProviderAccountViewModel()
            {
                Region = regions,
            };
            return model;
        }

        public ProviderMenuViewModel GetRegionsforProvider()
        {
            var regions = _adminRepo.GetRegionTable();
            ProviderMenuViewModel model = new ProviderMenuViewModel()
            {
                RegionList = regions,
            };
            return model;
        }

        public ProviderMenuViewModel GetProvidersdetails(int regionId)
        {
            var modal = _adminRepo.GetProviderRepo(regionId);
            return modal;

        }

        public CreateProviderAccountViewModel GetRegionsforPhysician()
        {
            var regions = _adminRepo.GetRegionTable();
            CreateProviderAccountViewModel model = new CreateProviderAccountViewModel()
            {
                Region = regions,
            };
            return model;

        }

        public void CreateAdmin(CreateAdminAccountViewModel model)
        {
            _adminRepo.CreateAdminRepo(model);
        }

        public SchedulingViewModel GetRegionsforShift()
        {
            var regions = _adminRepo.GetRegionTable();
            SchedulingViewModel model = new SchedulingViewModel()
            {
                RegionList = regions,
            };
            return model;
        }

        public void CreateNewShift(SchedulingViewModel model)
        {
            _adminRepo.CreateNewStateData(model);
        }

        public void UpdateBusinessProfileBilling(AdminProfileViewModel model)
        {
            _adminRepo.UpdateBillingRepo(model);
        }

        public void UpdateAdminInformation(AdminProfileViewModel model)
        {
            _adminRepo.UpdateAdminInfoRepo(model);
        }

        public ProviderLocationViewModel GetProviderList()
        {
            return _adminRepo.GetPhysicianLocationList();
        }

        public void CreateProvider(CreateProviderAccountViewModel model)
        {
            _adminRepo.CreateProviderRepo(model);
        }

        public Admin GetAdminByEmail(string email, string password)
        {
            return _adminRepo.GetAdminByMailRepo(email, password);
        }

        public UserInfoViewModel CheckValidUserWithRole(string email, string password)
        {
            var model = _adminRepo.GetRoleByAspNetId(email, password);
            return model;
        }
    }
}
