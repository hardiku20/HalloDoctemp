using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class RecordsViewModel
    {
        public List<User> Users { get; set; }
      

        public List<PatientHistory> patientHistory { get; set; }

        public List<PatientRecords> patientRecords { get; set; }

        public List<SearchRecords> searchRecords { get; set; }



        public class PatientHistory
        {
            public int UserId {  get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set;}

            public string? street { get; set; }
            public string? city { get; set; }
            public string? state { get; set; }
            public string? zipcode { get; set; }

            public string? Address { get; set; }
        }

        public class PatientRecords
        {
            public int UserId { get; set;}
            public string? Client { get; set;}
            public DateTime? CreatedDate {  get; set; }

            public string? ConfirmationNumber { get; set; }
            public string? ProviderName { get; set;}

            public DateTime? ConcludeDate { get; set;}

            public int? Status { get; set;}

            public int? requestId { get; set; }

        }



        public class SearchRecords
        {
            public string? PatientName { get; set;}
            public string? Requester { get; set;}
            public string? Email { get; set;}
            public string? PhoneNumber { get; set;}
            public string? Address { get; set;}
            public string? Zipcode { get; set;}
            public int? RequestStatus { get; set;}
            public string? Physician { get; set;}
            public string? PhysicianNote { get; set;}
            public string? AdminNote { get; set;}
            public int? RequestId  { get; set;}
        }

       




    }
}
