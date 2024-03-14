using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using learning1.Repositories.IRepositories;
using learning1.Repositories.Repositories;
using learning1.Services.IServices;
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
                    Name = x.FirstName + " " + x.LastName,
                    Address = x.RequestClients.Select(x =>x.Address).FirstOrDefault(),
                    Requester = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,
                }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = temp,
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

        public AdminDashboardViewModel RenderActiveStateData(int status1, int status2)
        {
            var model = _adminRepo.RenderToActiveState(status1,status2 );
            return model;
        }

        public AdminDashboardViewModel RenderConcludeStateData(int status)
        {
            var model = _adminRepo.RenderConcludeState(status);
            return model;
        }

        public AdminDashboardViewModel RenderNewStateData(int status)
        {
            var model = _adminRepo.RenderNewState(status);
            return model;
        }

        public AdminDashboardViewModel RenderPendingStateData(int status)
        {
            var model = _adminRepo.RenderPendingState(status);
            return model;
        }

        public AdminDashboardViewModel RenderToCloseStateData(int status1,int status2, int status3)
        {
            var model = _adminRepo.RenderToCloseState(status1 , status2,status3);
            return model;
        }

        public AdminDashboardViewModel RenderUnpaidStateData(int status)
        {
            var model = _adminRepo.RenderUnpaidState(status);
            return model;
        }

        public void SetViewNotesData(ViewNotesViewModel model, int requestId)
        {
            _adminRepo.SetViewNotes(model, requestId);
        }
    }
}
