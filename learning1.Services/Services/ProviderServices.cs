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
    public class ProviderServices : IProviderServices
    {
        private readonly IProviderRepo _providerRepo;

        public ProviderServices(IProviderRepo providerRepo) { 
             _providerRepo = providerRepo;
        }

        public ProviderDashboardViewModel DisplayProviderDashboard()
        {
            var Casetags = _providerRepo.DisplayCasetags();
            var Regions = _providerRepo.DisplayRegions();
            var Count = _providerRepo.SetCount();
            var temp = _providerRepo.DisplayProviderDashboardRepo().
                Select(x => new ProviderTableViewModel
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

            ProviderDashboardViewModel model = new ProviderDashboardViewModel()
            {
                TableViewModel = temp,
               CancellationReason = Casetags,
               Region = Regions,
               RequestCount = Count,
            };
            return model;
        }

        public ProviderDashboardViewModel RenderActiveStateData(int status1, int status2, int page, int pageSize, string patientName, string regionName, RequestType requestType)
        {
            var model = _providerRepo.RenderToActiveState(status1, status2, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderConcludeStateData(int status, int page, int pageSize, string patientName, string regionName, RequestType requestType)
        {
            var model = _providerRepo.RenderConcludeState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderNewStateData(int status, int page, int pageSize, string patientName, string regionName, RequestType requestType)
        {
            var model = _providerRepo.RenderNewState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }

        public ProviderDashboardViewModel RenderPendingStateData(int status, int page, int pageSize, string patientName, string regionName, RequestType requestType)
        {
            var model = _providerRepo.RenderPendingState(status, page, pageSize, patientName, regionName, requestType);
            return model;
        }
    }
}
