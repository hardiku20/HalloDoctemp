using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Repositories.IRepositories
{
    public interface IProviderRepo
    {
        List<string> DisplayCasetags();
        List<Request> DisplayProviderDashboardRepo(int physicianId);
        List<string> DisplayRegions();
        ViewCaseViewModel DisplayViewCaseRepo(int requestId);
        ProviderDashboardViewModel RenderConcludeState(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        ProviderDashboardViewModel RenderNewState(int status,int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        ProviderDashboardViewModel RenderPendingState(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        ProviderDashboardViewModel RenderToActiveState(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        public RequestCount SetCount(int physicianId);
    }
}
