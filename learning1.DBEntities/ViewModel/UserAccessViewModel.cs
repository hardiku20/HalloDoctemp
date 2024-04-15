using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class UserAccessViewModel
    {
        public string AccountPOC {  get; set; }
        public string AccountType {  get; set; }
        public string PhoneNumber {  get; set; }
        public int Status {  get; set; }
        public int Id {  get; set; }

       
    }
}
