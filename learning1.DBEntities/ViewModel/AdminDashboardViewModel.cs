using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class AdminDashboardViewModel
    {
        public string? Name { get; set; }
        public int RequestId { get; set; }

        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? PatientPhone { get; set; }

        public string? PatientEmail {  get; set; }
        public DateTime RequestedDate { get; set; }
        public List<AdminTableViewModel> TableViewModel { get; set; }
       
        public string? ReasonForCancellation { get; set; }
        public List<string>? Region {  get; set; }
        public string? SelectedRegion {  get; set; }

        public string? SelectedTransferRegion {  get; set; }
        public List<string>? CancellationReason { get; set; }

        public string? CancelNotes { get; set; }

        public string? BlockNotes { get; set; }

        public string? SelectedPhysician {  get; set; }

        public string? SelectedTransferPhysician { get; set; }

        public string? AssignCaseDescription {  get; set; }
        public RequestCount RequestCount { get; set; }
        public List<ExportDataViewModel> ExportViewModel { get; set; }
    }

    public class AdminTableViewModel
    {
        public string? Name { get; set; }
        public int RequestId { get; set; }
        public string? RequestedDate { get; set; }
        public string? Address {  get; set; }
        public string? Phone {  get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode {  get; set; }
        public string? Requester {  get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
        public string? RequestNotes { get; set; }
        public RequestType? RequestType { get; set; }

   
    }


    public class ExportDataViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RequestorLastname { get; set; }
        public string? RequestorFirstname { get; set; }
        public string? Strmonth { get; set; }
        public int? Intyear { get; set; }
        public int? Intdate { get; set; }

        public string? ConfirmationNumber { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public string? Street { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        public int? RequestId { get; set; }
        public int? RequestTypeId { get; set; }
        public int? Status { get; set; }
        public string? Zipcode { get; set; }
        public string? Phonenumber { get; set; }

        public DateTime? Createddate { get; set; }

    }


    public class RequestCount
    {
        public int? NewStateCount { get; set; }
        public int? PendingStateCount { get; set; }
        public int? ActiveStateCount { get; set; }
        public int? ConcludeStateCount { get; set; }
        public int? ToCloseStateCount { get; set; }
        public int? UnpaidStateCount { get; set; }
    }

    public enum RequestType
    {
        Business= 1,
        Patient = 2,
        Family = 3,
        Concierge = 4,
        All = 5,
    }
}