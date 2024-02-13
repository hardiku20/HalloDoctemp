using System.ComponentModel.DataAnnotations;

namespace learning1.ViewModel
{
    public class PatientRequestViewModel
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set;}
        [Required]
        public string DateofBirth { get; set;}
        [Required]
        public string Street { get; set;}
        [Required]
        public string City { get; set;}
        [Required]
        public string State { get; set;}
        [Required]
        public string ZipCode { get; set;}

        public IFormFile formFile { get; set; }

    }
}
