using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learning1.DBEntities.Models;

namespace learning1.DBEntities.ViewModel
{
    public class AdminProfileViewModel
    {
        public int AdminId { get; set; }
        public string? userName {  get; set; }
        public string? password { get; set; }
        public string? status {  get; set; }
        public string? role { get; set; }
        public string? firstName {  get; set; }
        public string? lastName { get; set; }
        public string? Email { get; set; }
        public string? confirmEmail {  get; set; }
        public string? Phone { get; set; }

        public List<Region> Region { get; set; }

        public List<int> AdminRegions {  get; set; }
        public string? Address1 {  get; set; }
        public string? Address2 { get; set;}

        public string? City {  get; set; }
        public string? State {  get; set; }
        public string? Zip { get; set;}
        public string? MailingPhone { get; set;}
    }
}
