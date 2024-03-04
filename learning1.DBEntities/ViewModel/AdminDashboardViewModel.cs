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
        public DateTime RequestedDate { get; set; }
        public List<AdminTableViewModel> TableViewModel { get; set; }

        public string? ReasonForCancellation { get; set; }
        public List<string>? Region {  get; set; }

        public List<string>? CancellationReason { get; set; }

        public string? CancelNotes { get; set; }

        
    }

    public class AdminTableViewModel
    {
        public string? Name { get; set; }
        public int RequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? Address {  get; set; }
        public string? Phone {  get; set; }

        public string? PatientNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode {  get; set; }
        public string? Requester {  get; set; }
        public int? Status { get; set; }
        public RequestType? RequestType { get; set; }

   
    }

    public enum RequestType
    {
        Business= 1,
        Patient = 2,
        Family = 3,
        Concierge = 4
    }
}
