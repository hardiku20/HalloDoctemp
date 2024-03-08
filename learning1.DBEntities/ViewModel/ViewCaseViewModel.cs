using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ViewCaseViewModel
    {
        public string? userName { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public string? phone {  get; set; }
        public string? email { get; set; }

        public DateTime? dateofbirth { get; set; }

        
        public string? Address { get; set; }
        public string? Region { get; set; }

        public string? Room {  get; set; }
    }
}
