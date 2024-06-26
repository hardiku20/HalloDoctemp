﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learning1.DBEntities.Models;
namespace learning1.DBEntities.ViewModel
{
   public class CreateAdminAccountViewModel
   {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role {  get; set; }

        public string? FirstName {  get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }

        public string? ConfirmEmail {  get; set; }
        public string? Phone { get; set; }

        public string? Address1 {  get; set; }
        public string? Address2 { get; set;}
        public string ? City {  get; set; }
        public string? State { get; set; }
        public string? Zip { get; set;}
         

        public int? regionId {  get; set; }

        public string? MailingPhone {  get; set; }

        public List<Region>? Region { get; set; }

        public List<int> AdminRegions { get; set; }
    }
}
