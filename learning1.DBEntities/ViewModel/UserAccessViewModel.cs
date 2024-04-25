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
        public List<UserAccessDetails> UserAccessList { get; set; } = new List<UserAccessDetails>();

        public List<Role> Roles { get; set; } = new List<Role>();

      
    }

    public class UserAccessDetails
    {
        public string AspId { get; set; } = string.Empty;

        public int AccountTypeId { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public int? Status { get; set; } = 0;

        public int OpenRequest { get; set; }

        public int? RoleId { get; set; } = 0;

    }

  
}
