using learning1.DBEntities.Models;
using learning1.DBEntities.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        void GetAssignCaseData(AdminDashboardViewModel model, int requestId);
        List<string> GetAvailablePhysicianByRegion(string regionName);
        void GetBlockCaseData(AdminDashboardViewModel model);
        List<string> GetBusinessByProfession(string professionName);
        void GetCancelCaseData(AdminDashboardViewModel model);
        SendOrderViewModel GetDetailsByBusiness(string businessName);
        SendOrderViewModel GetOrderdetails();
        List<string> GetPhysicianByRegion(string regionName);
        void GetTransferCaseData(AdminDashboardViewModel model, int requestId);
        ViewNotesViewModel GetViewNotesData(int requestId);
        ViewUploadViewModel GetviewUploads(int requestId);
        void InsertOrderDetails(SendOrderViewModel model);
        void InsertviewUploads(ViewUploadViewModel model, int requestId);
        void IsClearCase(AdminDashboardViewModel model);
        AdminDashboardViewModel RenderActiveStateData(int status1,int status2,int page, int pageSize, string patientName);
        AdminDashboardViewModel RenderConcludeStateData(int status, int page, int pageSize, string patientName);
        AdminDashboardViewModel RenderNewStateData(int status,int page,int pageSize,string patientName, DBEntities.ViewModel.RequestType requestType);
        AdminDashboardViewModel RenderPendingStateData(int status, int page, int pageSize, string patientName);
        AdminDashboardViewModel RenderToCloseStateData(int status1,int status2,int status3, int page, int pageSize, string patientName);
        AdminDashboardViewModel RenderUnpaidStateData(int status, int page, int pageSize, string patientName);
        void SetViewNotesData(ViewNotesViewModel model, int requestId);
        AdminDashboardViewModel ListToExportAllData();
        void SendAgreement(int requestId);
       EncounterFormViewModel GetEncounterformData(int requestId);
        int LoginMethod(string email, string password);
        void SendlinktoPatient(AdminDashboardViewModel model);
        void CreatePatientRequest(CreateRequestViewModel model);
        CreateAdminAccountViewModel GetRegionforAdmin();
        AdminProfileViewModel GetAdminProfileData(int AdminId);
        List<Menu> GetMenus(int accountType);
        void CreateRoleByAccount(CreateRoleViewModel model);
        AccountAccessViewModel GetAccountAccessTable();
        CreateRoleViewModel GetDetailsByRoleId(int roleId);
        void DeleteRoleById(int roleId);
        List<ShiftDetail> GetScheduleData();
        List<Region> getRegionTableData();
        List<ProviderMenuDetailsViewModel> GetPhysicianDataByRegion(int regionId);
        AddBusinessViewModal GetProfession();
        void AddNewBusiness(AddBusinessViewModal modal);
        
        AddBusinessViewModal GetBusinessByVendorId(int vendorId);
        void UpdateBusiness(AddBusinessViewModal modal);
        void DeleteBusinessByVendor(int vendorId);
        VendorViewModel GetVendorsDetails(int professionId, string vendorName);
        RecordsViewModel GetPatientHistory(string firstname, string lastname, string email, string phonenumber);
        RecordsViewModel GetPatientExplore(int userId);
        RecordsViewModel GetSearchData();



        //AccountAccessViewModel EditRoleById(int roleId);
        //List<string> GetMenuList(int accountType);
    }
}
