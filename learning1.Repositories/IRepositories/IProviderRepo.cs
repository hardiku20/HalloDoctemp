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
        void acceptcase(int requestId);
        void AddRequestNote(RequestNote requestnote);
        void AddShift(Shift shift);
        void AddShiftDetail(ShiftDetail shiftDetail1);
        List<string> DisplayCasetags();
        List<string> DisplayProfession();
        List<Request> DisplayProviderDashboardRepo(int physicianId);
        List<string> DisplayRegions();
        ViewCaseViewModel DisplayViewCaseRepo(int requestId);
        ViewUploadViewModel FetchViewUploads(int requestId);
        Physician GetProviderByMailRepo(string email, string password);
        List<string> GetBusinessByProfessionName(string professionName);
        ViewNotesViewModel GetNoteDataById(int requestId);
        SendOrderViewModel GetOrder(string businessName);
        Dictionary<int, string> GetPhysicianRegionList(int physicianId);
        ProviderProfileViewModel GetProviderProfileRepo(int physicianId);
        UserInfoViewModel GetRoleByAspNetId(string email, string password);
        RequestNote GetRquestNoteById(int requestId);
        List<ShiftDetail> GetShiftDetailData(int physicianId, int regionId);
        int LoginMethodRepo(string email, string password);
        void OrderDetailRepo(SendOrderViewModel model);
        ProviderDashboardViewModel RenderConcludeState(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        ProviderDashboardViewModel RenderNewState(int status,int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        ProviderDashboardViewModel RenderPendingState(int status, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        ProviderDashboardViewModel RenderToActiveState(int status1, int status2, int physicianId, int page, int pageSize, string patientName, string regionName, DBEntities.ViewModel.RequestType requestType);
        void SaveRecentChanges();
        public RequestCount SetCount(int physicianId);
        void TransferCaseRepo(ProviderDashboardViewModel model, int requestId);
        void UpdateNotes(RequestNote requestNote);
        ViewUploadViewModel Uploaddocuments(ViewUploadViewModel model, int requestId);
        void HousecallRepo(int requestId);
        void AgreementMails(int requestId);
        void ConsultRepo(int requestId);
        CloseCaseViewModel ConcludeCareRepo(int requestId);
        void AddRequestWiseFile(RequestWiseFile requestwisefile);
        Request GetRequestById(int requestId);
        void UpdateRequest(Request req);
        void AddRequestStatusLog(RequestStatusLog requestStatusLog);
        EncounterFormViewModel GetEncounterformRepo(int requestId);
        void EncounterFormRepo(EncounterFormViewModel model);
        void ConcludeCareStatusRepo(int requestId);
        Timesheet? GetTimesheetByDate(DateOnly firstDate, DateOnly lastDate, int physicianId);
        bool UpdateTimesheet(Timesheet timesheet);
        TimesheetReimbursement? GetTimesheetReimbursementByDateAndTimeSheetId(DateOnly shiftDate, int timeSheetId);
        bool DeleteTimesheetReimbursement(TimesheetReimbursement data);
        TimesheetReimbursement? CreateTimesheetReimbursement(TimesheetReimbursement receipt1);
        void UpdateTimesheetReimbursement(TimesheetReimbursement createdReceipt);
        TimesheetDetail GetTimesheetDetailById(int timesheetDetailId);
        bool UpdateRangeTimesheetDetail(List<TimesheetDetail> timesheetDetailsUpdate);
        IEnumerable<TimesheetReimbursement> GetTimesheetReimbursementByTimeSheetId(int timesheetId);
        IEnumerable<TimeSheetDetailVM> GetTimeSheetData(int timesheetId, int physicianId);
        void CreateRangeTimesheetDetail(List<TimesheetDetail> timesheetDetailsInsert);
        decimal? GetTotalShiftHours(DateOnly date, int physicianId);
        Timesheet? CreateTimeSheet(Timesheet timesheet1);
        IEnumerable<TimeSheetDetailStatic>? GetTimeSheetDetailStaticData(int timesheetId);
    }
}
