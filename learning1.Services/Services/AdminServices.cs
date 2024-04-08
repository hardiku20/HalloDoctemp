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

        public ViewNotesViewModel GetViewNotesData(int requestId)
        {
            var model = _adminRepo.GetViewNotesRepo(requestId);
            return model;
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



        //public void GetCancelCaseData(AdminDashboardViewModel model)
        //{
        //    var request = _adminRepo.GetRequestById(model.RequestId);
        //    request.Status = 3;
        //    _adminRepo.updateRequest(request);

        //    RequestStatusLog requestStatusLog = new RequestStatusLog()
        //    {
        //        RequestId = model.RequestId,
        //        Status = request.Status,
        //        CreatedDate = request.CreatedDate,
        //        Notes = model.CancelNotes,
        //    };
        //    _adminRepo.AddRequestStatusLog(requestStatusLog);

        //}

        public AdminDashboardViewModel RenderActiveStateData(int status1, int status2 ,int page, int pageSize, string patientName)
        {
            var model = _adminRepo.RenderToActiveState(status1, status2 ,page, pageSize, patientName);
            return model;
        }

        public AdminDashboardViewModel RenderConcludeStateData(int status, int page, int pageSize, string patientName)
        {
            var model = _adminRepo.RenderConcludeState(status, page, pageSize, patientName);
            return model;
        }

        public AdminDashboardViewModel RenderNewStateData(int status,int page,int pageSize,string patientName, DBEntities.ViewModel.RequestType requestType)
        {
            var model = _adminRepo.RenderNewState(status, page, pageSize, patientName,requestType);
            return model;
        }

        public AdminDashboardViewModel RenderPendingStateData(int status, int page, int pageSize, string patientName)
        {
            var model = _adminRepo.RenderPendingState(status, page, pageSize, patientName);
            return model;
        }

        public AdminDashboardViewModel RenderToCloseStateData(int status1,int status2, int status3, int page, int pageSize, string patientName)
        {
            var model = _adminRepo.RenderToCloseState(status1 , status2,status3, page, pageSize, patientName);
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidStateData(int status, int page, int pageSize, string patientName)
        {
            var model = _adminRepo.RenderUnpaidState(status, page, pageSize, patientName);
            return model;
        }

        //public void SendAgreementData(string email, int requestId)
        //{
        //    _adminRepo.Mails(email, requestId);
        //}

        //public void SendAgreementData(AdminDashboardViewModel model, int requestId)
        //{
        //    _adminRepo.SendAgreementRepo(model, requestId);
        //}

        //public void SendLinkData(AdminDashboardViewModel model)
        //{
        //    _adminRepo.SendLinkRepo(model);
        //}

        public void SetViewNotesData(ViewNotesViewModel model, int requestId)
        {
            _adminRepo.SetViewNotes(model, requestId);
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
            var modal = _adminRepo.GetVendorRepo(professionId,vendorName);
            return modal;
        }


        //public AccountAccessViewModel EditRoleById(int roleId)
        //{
        //    var model = _adminRepo.EditRoleRepo(roleId);
        //    return model;
        //}
    }
}
