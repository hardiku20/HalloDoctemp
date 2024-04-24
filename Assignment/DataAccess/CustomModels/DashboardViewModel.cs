using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomModels
{
    public class DashboardViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
  
        public string? Age { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    
        public string? Gender { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        public List<Dashboardtable> dashboardtables { get; set; }

        public class Dashboardtable
        {
            public int? Id { get; set; }

            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }

            public string? Age { get; set; }
            public string? PhoneNumber { get; set; }

            public string? Gender { get; set; }

            public string? City { get; set; }

            public string? Country { get; set; }
        }

    }
}
