using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class VendorViewModel
    {
      
        public List<VendorTableViewModal> VendorTableViewModals { get; set; }
        public List<HealthProfessional> healthProfessionals { get; set; }

        public List<HealthProfessionalType> ProfessionalTypes { get; set; }

        public int TotalRecord { get; set; }
        public int ShowRecords { get; set; }

        public class VendorTableViewModal
        {
            public int? VendorId { get; set; }
            public int Profession { get; set; }
            public string? BusinessName { get; set; }
            public string? Email { get; set; }
            public string? FaxNumber { get; set; }
            public string? PhoneNumber { get; set; }
            public string? BusinessContact { get; set; }
        }



    }
}
