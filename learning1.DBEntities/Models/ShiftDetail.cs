﻿using System;
using System.Collections.Generic;

namespace learning1.DBEntities.Models;

public partial class ShiftDetail
{
    public int ShiftDetailId { get; set; }

    public int ShiftId { get; set; }

    public DateTime ShiftDate { get; set; }

    public int? RegionId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public short Status { get; set; }

    public bool IsDeleted { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? LastRunningDate { get; set; }

    public string? EventId { get; set; }

    public bool? IsSync { get; set; }

    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    public virtual Shift Shift { get; set; } = null!;

    public virtual ICollection<ShiftDetailRegion> ShiftDetailRegions { get; set; } = new List<ShiftDetailRegion>();
}
