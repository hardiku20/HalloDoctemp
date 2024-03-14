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
        void AssignCaseRepo(AdminDashboardViewModel model, int requestId);
        void BlockCaseRepo(AdminDashboardViewModel model);
        void CancelCaseRepo(AdminDashboardViewModel model);
        void ClearCaseRepo(AdminDashboardViewModel model);

        //void AddRequestStatusLog(RequestStatusLog requestStatusLog);
        //void CancelCaseDataRepo(AdminDashboardViewModel model);
        //void updateRequest(Request request);
        //Request GetRequestById(int requestId);
        List<Request> DisplayAdminDashboardRepo();

        public RequestCount SetCount();
        List<string> DisplayCasetags();
        List<string> DisplayProfession();
        List<string> DisplayRegions();
        ViewCaseViewModel DisplayViewCaseRepo(int requestId);
        ViewUploadViewModel FetchViewUploads(int requestId);
        List<string> GetAvailablePhysicianByRegionName(string regionName);
        List<string> GetBusinessByProfessionName(string professionName);
        SendOrderViewModel GetOrder(string businessName);
        List<string> GetPhysicianByRegionName(string regionName);
        ViewNotesViewModel GetViewNotesRepo(int requestId);
        void OrderDetailRepo(SendOrderViewModel model);

        //void OrderdetailsRepo(SendOrderViewModel model);
        AdminDashboardViewModel RenderConcludeState(int status);
        AdminDashboardViewModel RenderNewState(int status);
        AdminDashboardViewModel RenderPendingState(int status);
        AdminDashboardViewModel RenderToActiveState(int status1,int status2);
        AdminDashboardViewModel RenderToCloseState(int status1, int status2,int status3);
        AdminDashboardViewModel RenderUnpaidState(int status);
        void SetViewNotes(ViewNotesViewModel model, int requestId);
        void TransferCaseRepo(AdminDashboardViewModel model, int requestId);
        ViewUploadViewModel Uploaddocuments(ViewUploadViewModel model, int requestId);
    }
}
