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
            var temp = _adminRepo.DisplayAdminDashboardRepo().
                Select(x => new AdminTableViewModel
                {
                    RequestId = x.RequestId,
                    RequestedDate = x.CreatedDate,
                    Phone = x.PhoneNumber,
                    Name = x.FirstName + " " + x.LastName,
                    Address = x.RequestClients.Select(x =>x.Address).FirstOrDefault(),
                    Requester = x.FirstName + " " + x.LastName,
                    PatientNumber = x.PhoneNumber,
                    RequestType = (DBEntities.ViewModel.RequestType)x.RequestTypeId,

                }).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                TableViewModel = temp,
                CancellationReason = Casetags,
                Region = Regions,       
            };
            return model;
        }

        public ViewCaseViewModel DisplayViewCase(int requestId)
        {
            var model = _adminRepo.DisplayViewCaseRepo(requestId);
            return model;
        }

        public void GetBlockCaseData(AdminDashboardViewModel model)
        {
            _adminRepo.BlockCaseRepo(model);
        }

        public void GetCancelCaseData(AdminDashboardViewModel model)
        {
            _adminRepo.CancelCaseRepo(model);
        }

        public List<string> GetPhysicianByRegion(string regionName)
        {
            var physicianName = _adminRepo.GetPhysicianByRegionName(regionName);
            return physicianName;
        }

        public ViewUploadViewModel GetviewUploads(int requestId)
        {
           var model= _adminRepo.FetchViewUploads(requestId);
           return model;
        }

        public void InsertviewUploads(ViewUploadViewModel model, int requestId)
        {
            _adminRepo.Uploaddocuments(model, requestId);
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
    }
}
