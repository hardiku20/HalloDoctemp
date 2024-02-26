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

    }

    public class AdminTableViewModel
    {
        public string? Name { get; set; }
        public int RequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? Address {  get; set; }
        public string? Phone {  get; set; }

        public string? Requester {  get; set; }
    }
}
