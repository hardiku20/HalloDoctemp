using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class SendOrderViewModel
    {
        public List<string>? Profession {  get; set; }

        public List<string>? Business { get; set;}

        public string? BusinessContact {  get; set; }

        public string? Email { get; set; }

        public string? FaxNumber { get; set;}
        public string? OrderNotes {  get; set; }
        public int? No_of_Refills { get; set;}
        public int? VendorId { get; set; }

        public int? RequestId { get; set; }
    }
}
