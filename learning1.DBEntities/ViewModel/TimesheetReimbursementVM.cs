using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class TimesheetReimbursementVM
    {
        [Required]
        public int TimesheetId { get; set; }

        [Required]
        public string? Item { get; set; }

        [Required]
        public int Amount { get; set; }

        public IFormFile? ReceiptDoc { get; set; }

        [Required]
        public DateOnly ShiftDate { get; set; }
    }
}
