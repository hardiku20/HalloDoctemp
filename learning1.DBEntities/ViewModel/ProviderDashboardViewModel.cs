using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ProviderDashboardViewModel
    {
        public string? Name { get; set; }
        public int RequestId { get; set; }

        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? PatientPhone { get; set; }
        public string? PatientEmail { get; set; }
        public DateTime RequestedDate { get; set; }
        public List<ProviderTableViewModel> TableViewModel { get; set; }

        public string? ReasonForCancellation { get; set; }
        public List<string>? Region { get; set; }
        public string? SelectedRegion { get; set; }

        public string? SelectedTransferRegion { get; set; }
        public List<string>? CancellationReason { get; set; }

        public string? CancelNotes { get; set; }

        public string? BlockNotes { get; set; }
        public string? TransferNotes { get; set; }

        public string? SelectedPhysician { get; set; }

        public string? SelectedTransferPhysician { get; set; }

        public string? AssignCaseDescription { get; set; }
        public RequestCount RequestCount { get; set; }
        public int TotalRecord { get; set; }
        public int ShowRecords { get; set; }
        public List<ExportDataViewModel> ExportViewModel { get; set; }
    }
    public class ProviderTableViewModel
    {
        public string? Name { get; set; }
        public int RequestId { get; set; }
        public string? RequestedDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Requester { get; set; }
        public string? Email { get; set; }
        public int? Status { get; set; }
        public string? RequestNotes { get; set; }
        public RequestType? RequestType { get; set; }


    }
}
