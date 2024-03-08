using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.IServices
{
    public interface IAdminServices
    {
        AdminDashboardViewModel DisplayAdminDashboard();
        ViewCaseViewModel DisplayViewCase(int requestId);
        void GetBlockCaseData(AdminDashboardViewModel model);
        List<string> GetBusinessByProfession(string professionName);
        void GetCancelCaseData(AdminDashboardViewModel model);
        SendOrderViewModel GetDetailsByBusiness(string businessName);
        SendOrderViewModel GetOrderdetails();

        //void GetOrderdetails(SendOrderViewModel model);
        List<string> GetPhysicianByRegion(string regionName);
        ViewUploadViewModel GetviewUploads(int requestId);
        void InsertOrderDetails(SendOrderViewModel model);
        void InsertviewUploads(ViewUploadViewModel model, int requestId);
        AdminDashboardViewModel RenderActiveStateData(int status1,int status2);
        AdminDashboardViewModel RenderConcludeStateData(int status);
        AdminDashboardViewModel RenderNewStateData(int status);
        AdminDashboardViewModel RenderPendingStateData(int status);
        AdminDashboardViewModel RenderToCloseStateData(int status1,int status2,int status3);
        AdminDashboardViewModel RenderUnpaidStateData(int status);
    }
}
