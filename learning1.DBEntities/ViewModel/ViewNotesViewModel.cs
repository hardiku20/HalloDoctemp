using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ViewNotesViewModel
    {
        public int RequestId {  get; set; }
        public int NoteId { get; set; }
        public string? PhysicianName { get; set; }
        public string? AdminNotes {  get; set; }
        public string? PhysicianNotes {  get; set; }
        public DateTime? CreatedDate { get; set;}
         public string? CreatedBy { get; set; }
        [StringLength(150)]
        public string? AdditionalNotes { get; set; }
        public List<RequestStatusLog> TransferNotes { get; set; }

    }
    
}
