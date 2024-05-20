using learning1.DBEntities.ViewModel;
using Microsoft.AspNetCore.Http;
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
        UserInfoViewModel CheckValidUserWithRole(string email, string password);
        void clickConsult(int requestId);
        void clickHousecall(int requestId);
        bool ConcludeCare(int id, CloseCaseViewModel modal);
        void ConcludeCareService(int requestId);
        IEnumerable<TimeSheetDetailVM> CreateInvoiceSheet(DateOnly firstDate, DateOnly lastDate);
        bool DeleteTimesheetReimbursement(int timeSheetId, DateOnly shiftDate);
        ProviderDashboardViewModel DisplayProviderDashboard(int physicianId);
        ViewCaseViewModel DisplayViewCase(int requestId);
        void EncounterforData(EncounterFormViewModel model);
        bool FinalizeInvoice(DateOnly firstDate, DateOnly lastDate);
        List<string> GetBusinessByProfession(string professionName);
        CloseCaseViewModel GetConcludeCare(int requestId);
        string GetContentType(string filePath);
        SendOrderViewModel GetDetailsByBusiness(string businessName);
        EncounterFormViewModel GetEncounterform(int requestId);
        InvocingViewModel GetInvoiceData(DateOnly firstDate, DateOnly lastDate, string aspNetId);
        InvoiceReciept GetInvoiceReceipt(DateOnly firstDate, DateOnly lastDate);
        ViewNotesViewModel GetNotesById(int requestId);
        SendOrderViewModel GetOrderdetails();
        DBEntities.Models.Physician GetPhysicianByEmail(string email, string password);
        Dictionary<int, string> GetPhysicianRegionList(int physicianId);
        ProviderProfileViewModel GetProviderProfileData(int physicianId);
        List<DBEntities.Models.ShiftDetail> GetProviderScheduleData(int physicianId, int v);
        void GetTransferCaseData(ProviderDashboardViewModel model, int requestId);
        ViewUploadViewModel GetviewUploads(int requestId);
        void InsertOrderDetails(SendOrderViewModel model);
        void InsertviewUploads(ViewUploadViewModel model, int requestId);
        int LoginMethod(string email, string password);
        ProviderDashboardViewModel RenderActiveStateData(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderConcludeStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderNewStateData(int status,int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        ProviderDashboardViewModel RenderPendingStateData(int status, int physicianId, int page, int pageSize, string patientName, string regionName, RequestType requestType);
        void SendAgreement(int requestId);
        bool SetCreateNewShiftData(ProviderSchedulingViewModel model);
        void SetNotesById(ViewNotesViewModel model);
        bool UpdateInvoiceSheetData(List<SheetData> sheetData);
        bool UploadConcludeDocument(IFormFile fileforConcludeCare, int reqId);
        bool UploadReceipt(TimesheetReimbursementVM receipt);
    }
}
