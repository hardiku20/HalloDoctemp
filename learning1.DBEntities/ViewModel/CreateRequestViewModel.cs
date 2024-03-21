using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class CreateRequestViewModel
    {

        public int? RequestId { get; set; }
        public int? Status {  get; set; }
        public string? FirstName {  get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public string? Phone {  get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State {  get; set; }
        public string? ZipCode { get; set;}

        public string? Room { get; set; }

        public string? AdminNotes { get; set;}

        public string? PhysicianNotes { get; set; }


    }
}
