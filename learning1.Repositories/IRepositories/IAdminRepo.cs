using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        AdminDashboardViewModel RenderConcludeState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        AdminDashboardViewModel RenderNewState(int status,int page,int pageSize,string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        AdminDashboardViewModel RenderPendingState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        AdminDashboardViewModel RenderToActiveState(int status1,int status2, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        AdminDashboardViewModel RenderToCloseState(int status1, int status2,int status3, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        AdminDashboardViewModel RenderUnpaidState(int status, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        void SetViewNotes(ViewNotesViewModel model, int requestId);
        void TransferCaseRepo(AdminDashboardViewModel model, int requestId);
        ViewUploadViewModel Uploaddocuments(ViewUploadViewModel model, int requestId);
        AdminDashboardViewModel ListToExportAllData();
        void Mails(int requestId);
        EncounterFormViewModel GetEncounterRepo(int requestId);
        int LoginMethodRepo(string email, string password);
        void SendlinkMail(AdminDashboardViewModel model);
        void CreateRequestRepo(CreateRequestViewModel model);
        List<Region> GetRegionTable();
        AdminProfileViewModel GetAdminProfileRepo(int adminId);
        List<Menu> GetMenuRepo(int accountType);
        void CreateRoleRepo(CreateRoleViewModel model);
        AccountAccessViewModel GetAccountAccessRepo();
        CreateRoleViewModel GetRoleDetailsRepo(int roleId);
        void DeleteRoleRepo(int roleId);
        List<ShiftDetail> GetScheduleData();
        List<ProviderMenuDetailsViewModel> ProviderMenuTableDetails(int regionId);
        List<HealthProfessionalType> DisplayProfessionlist();
        void AddBusinessRepo(AddBusinessViewModal modal);
        AddBusinessViewModal GetBusinessRepo(int vendorId);
        void UpdateBusinessRepo(AddBusinessViewModal modal);
        void DeleteBusinessRepo(int vendorId);
        VendorViewModel GetVendorRepo(int professionId, string vendorName);
        RecordsViewModel PatientHistoryRepo(string firstname,string lastname,string email,string phonenumber);
        RecordsViewModel PatientExploreRepo(int userId);
        RecordsViewModel SearchDataRepo(string patientName, string providerName, string email, string phoneNumber);
        UserAccessViewModel GetUserAccessRepo();
        RecordsViewModel BlockDataRepo(string name, string date, string email, string phoneNumber);

        //AccountAccessViewModel EditRoleRepo(int roleId);
        //List<string> GetMenuListRepo(int accountType);
    }
}
