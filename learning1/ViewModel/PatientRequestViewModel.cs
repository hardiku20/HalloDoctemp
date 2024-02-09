using System.ComponentModel.DataAnnotations;

namespace learning1.ViewModel
{
    public class PatientRequestViewModel
    {

        [Required(ErrorMessage = "UserName is required")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string DateofBirth { get; set;}
        public string Street { get; set;}
        public string City { get; set;}
        public string State { get; set;}
        public string ZipCode { get; set;}

    }
}
