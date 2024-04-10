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






    }
}
