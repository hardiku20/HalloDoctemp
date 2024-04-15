using System.ComponentModel.DataAnnotations;

namespace learning1.DBEntities.ViewModel
{
    public class Family_FriendRequestViewModel
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Emailaddress { get; set; }
        public string Relation {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DateofBirth { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string RequestNotes { get; set; }
    }
}
