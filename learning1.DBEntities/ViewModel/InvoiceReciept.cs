using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class InvoiceReciept
    {
        public DateOnly FirstDate { get; set; }

        public DateOnly LastDate { get; set; }

        public int TimeSheetId { get; set; }

        public IEnumerable<TimesheetReimbursement> ReimbursementData { get; set; } = null!;
    }
}
