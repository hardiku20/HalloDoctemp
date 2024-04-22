using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ProviderProfileViewModel
    {


        public string? AdminAspID { get; set; }
        public int PhysicianId { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public List<Region> Region { get; set; }

        public List<int> PhysicianRegions { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? MailingPhone { get; set; }

        public int? regionId { get; set; }
    }
}
