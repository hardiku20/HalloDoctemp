using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class ProviderSchedulingViewModel
    {
        public int PhysicianId { get; set; }
        //public int? AdminId { get; set; }
        public Dictionary<int, string> RegionList { get; set; }

        //public string SelectedRegion { get; set; }
        public int regionId { get; set; }

        //Create Shift modal
        //[Range(1, int.MaxValue, ErrorMessage = "Please select region for shift.")]
        //public string regionSelector { get; set; }

        //[RegularExpression(@"^(?!\d+$)[a-zA-Z0-9]+$", ErrorMessage = "Please select Physician for shift.")]
        //public string PhysicianName { get; set; }

        [Required(ErrorMessage = "Shift date must be in YYYY-MM-DD format.")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid shift date format. Use YYYY-MM-DD.")]
        public DateOnly ShiftDate { get; set; }

        [Required(ErrorMessage = "Shift Start time is required.")]
        public TimeOnly StartTime { get; set; }

        [Required(ErrorMessage = "Shift End time is required.")]
        public TimeOnly EndTime { get; set; }
        public Boolean IsRepeat { get; set; }

        public int RepeatEnd { get; set; }

        public string SelectedDays { get; set; }

        //public ShiftDTO ShiftDTOViewModel { get; set; }
        //public ShiftViewDetailDTO shiftViewDetailDTO { get; set; }
    }
}
