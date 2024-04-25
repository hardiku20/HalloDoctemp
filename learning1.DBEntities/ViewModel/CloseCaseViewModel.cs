using learning1.DBEntities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class CloseCaseViewModel
    {
        public int ReqId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }
        public string ConfirmationNumber { get; set; }
        [RegularExpression(@"^[9876]\d{9}$", ErrorMessage = "must not start with digits 1-5 and have a length of 10 digits")]
        [Required(ErrorMessage = "Phonenubmber required")]
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public List<RequestWiseFile> Files { get; set; }
        public string? ProviderNotes { get; set; }

        public IFormFile? FileforConcludeCare { get; set; }
    }
}
