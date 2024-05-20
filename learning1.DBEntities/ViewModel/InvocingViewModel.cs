using learning1.DBEntities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class InvocingViewModel
    {
        public string? Username { get; set; }
        public string? PhysicianName { get; set; }

        public bool IsSheetFinalized { get; set; }
        public bool IsSheetApproved { get; set; }

        public Timesheet? Timesheet { get; set; }

        public Payrate? Payrate { get; set; }

        public IEnumerable<TimeSheetDetailVM>? Timesheets { get; set; }

        public IEnumerable<TimeSheetDetailStatic>? TimesheetDetails { get; set; }

        public IEnumerable<TimesheetReimbursement>? TimesheetReimbursements { get; set; }

        public List<SelectListItem>? Physicians { get; set; }

        public decimal TotalShiftHours { get; set; }

        public decimal TotalHouseCall { get; set; }

        public decimal TotalWeekend { get; set; }
        public decimal TotalPhoneConsult { get; set; }
        public decimal Total { get; set; }
    }
}
