using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class AddBusinessViewModal
    {
        [Required]
        public string BusinessName {  get; set; }
        [Required]
        public int Profession {  get; set; }
        [Required]
        public string FaxNumber {  get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email {  get; set; }
         [Required]
        public string BusinessContact {  get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }

        public List<HealthProfessionalType> ProfessionalTypes { get; set;}

       

    }
}
