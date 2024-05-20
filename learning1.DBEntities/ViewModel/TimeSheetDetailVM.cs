using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class TimeSheetDetailVM
    {
        public int TimesheetDetailId { get; set; }

        public double? OnCallHours { get; set; }

        public DateOnly? Shiftdate { get; set; }

        public decimal? ShiftHours { get; set; }

        public int? Housecall { get; set; }

        public int? PhoneConsult { get; set; }

        public bool? IsWeekend { get; set; }
    }
}
