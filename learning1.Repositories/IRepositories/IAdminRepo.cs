using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Repositories.IRepositories
{
    public interface IAdminRepo
    {
        void BlockCaseRepo(AdminDashboardViewModel model);
        void CancelCaseRepo(AdminDashboardViewModel model);

        //void AddRequestStatusLog(RequestStatusLog requestStatusLog);
        //void CancelCaseDataRepo(AdminDashboardViewModel model);
        //void updateRequest(Request request);
        //Request GetRequestById(int requestId);
        List<Request> DisplayAdminDashboardRepo();
        List<string> DisplayCasetags();
       List<string> DisplayRegions();
        ViewCaseViewModel DisplayViewCaseRepo(int requestId);
        ViewUploadViewModel FetchViewUploads(int requestId);
        List<string> GetPhysicianByRegionName(string regionName);
        AdminDashboardViewModel RenderConcludeState(int status);
        AdminDashboardViewModel RenderNewState(int status);
        AdminDashboardViewModel RenderPendingState(int status);
        AdminDashboardViewModel RenderToActiveState(int status1,int status2);
        AdminDashboardViewModel RenderToCloseState(int status1, int status2,int status3);
        AdminDashboardViewModel RenderUnpaidState(int status);
        ViewUploadViewModel Uploaddocuments(ViewUploadViewModel model, int requestId);
    }
}
