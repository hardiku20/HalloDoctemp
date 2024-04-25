using learning1.DBEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.DBEntities.ViewModel
{
    public class SchedulingViewModel
    {
        public int? AdminId { get; set; }
        public List<Region> RegionList { get; set; }

        public string SelectedRegion { get; set; }

        //Create Shift modal
        public string regionSelector { get; set; }

        public string PhysicianName { get; set; }

        public DateOnly ShiftDate { get; set; }

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public Boolean IsRepeat { get; set; }

        public int RepeatEnd { get; set; }

        public string SelectedDays { get; set; }

        public ShiftDTO ShiftDTOViewModel { get; set; }

        public ShiftViewDetailDTO shiftViewDetailDTO { get; set; }
    }
    public class ShiftDTO
    {
        public int Id { get; set; }
        public int resourceId { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
    }

    public class ProviderDTO
    {
        public int Id { get; set; }

        public string title { get; set; }

        public string imageUrl { get; set; }
    }

    public class ShiftViewDetailDTO
    {
        public int ShiftDetailId { get; set; }
        public int PhysicianRegionId { get; set; }
        public string? PhysicianRegionName { get; set; }
        public int PhysicianId { get; set; }
        public string? PhysicianName { get; set; }
        public string ShiftDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
