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


        public int VendorId { get; set; }



    
        public string BusinessName {  get; set; }
        [Required(ErrorMessage = "Please select a profession.")]
        public int Profession {  get; set; }
        [Required(ErrorMessage = "Please enter a fax number.")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Fax number must be between 10 and 14 digits (including country code).")]     
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]([0-9]{3})[-. ]([0-9]{4})$", ErrorMessage = "Invalid fax number format. Valid examples: (123) 456-7890, 123-456-7890, +1234567890")]
        public string FaxNumber {  get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 14 digits (including country code).")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]([0-9]{3})[-. ]([0-9]{4})$", ErrorMessage = "Invalid phone number format. Valid examples: (123) 456-7890, 123-456-7890, +1234567890")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Please enter a business contact name.")]
        [StringLength(100, ErrorMessage = "Business contact name cannot exceed 100 characters.")]
        public string BusinessContact {  get; set; }
        [Required(ErrorMessage = "Please enter a street address.")]
        [StringLength(100, ErrorMessage = "Street address cannot exceed 100 characters.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter a city name.")]
        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state name.")]
        [StringLength(50, ErrorMessage = "State name cannot exceed 50 characters.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a zip code.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Zip code must be between 5 and 10 characters.")]
        public string Zipcode { get; set; }

        public List<HealthProfessionalType> ProfessionalTypes { get; set;}

       

    }
}


