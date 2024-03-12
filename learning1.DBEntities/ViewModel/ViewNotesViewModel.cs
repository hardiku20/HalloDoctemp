using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ViewNotesViewModel
    {
        public int RequestId {  get; set; }
        public int NoteId { get; set; }
        public string? TransferNotes { get; set; }
        public string? PhysicianName { get; set; }
        public string? AdminNotes {  get; set; }
        public string? PhysicianNotes {  get; set; }
        public DateTime? CreatedDate { get; set;}
    }
}
