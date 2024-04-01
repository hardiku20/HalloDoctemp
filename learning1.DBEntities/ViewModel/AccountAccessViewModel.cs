using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class AccountAccessViewModel
    {
        public int RoleId { get; set; } 

        public string? Name {  get; set; }

        public string? AccountType {  get; set; }

        public List<Role> Roledata { get; set; }

    }
}
