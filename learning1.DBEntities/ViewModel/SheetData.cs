using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class SheetData
    {
        public double TotalHours { get; set; }

        public int TimesheetDetailId { get; set; }

        public bool IsWeekend { get; set; }

        public int Housecall { get; set; }

        public int PhoneConsult { get; set; }
    }
}
