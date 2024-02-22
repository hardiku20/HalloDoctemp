using System.ComponentModel.DataAnnotations;

namespace learning1.DBEntities.ViewModel
{
    public class ConciergeRequestViewModel
    {
        [Required(ErrorMessage = "Required")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Phone { get; set; }
        public string Emailaddress { get; set; }
        public string houseName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
