using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.IServices
{
    public interface IProviderServices
    {
        void acceptCase(int requestId);
        ProviderDashboardViewModel DisplayProviderDashboard(int physicianId);
        ViewCaseViewModel DisplayViewCase(int requestId);
        List<string> GetBusinessByProfession(string professionName);
        SendOrderViewModel GetDetailsByBusiness(string businessName);
        SendOrderViewModel GetOrderdetails();
        ProviderProfileViewModel GetProviderProfileData(int physicianId);
        void GetTransferCaseData(ProviderDashboardViewModel model, int requestId);
        ViewUploadViewModel GetviewUploads(int requestId);
        void InsertOrderDetails(SendOrderViewModel model);
        void InsertviewUploads(ViewUploadViewModel model, int requestId);
        ProviderDashboardViewModel RenderActiveStateData(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderConcludeStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderNewStateData(int status,int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderPendingStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
    }
}
