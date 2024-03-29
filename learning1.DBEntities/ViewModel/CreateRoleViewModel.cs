using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace learning1.DBEntities.ViewModel
{
    public class CreateRoleViewModel
    {
        public int? RoleId { get; set;}
        public string? RoleName { get; set;}

        public string? AccountType {  get; set;}

        public List<Menu> menulist {  get; set;}

    }
}
