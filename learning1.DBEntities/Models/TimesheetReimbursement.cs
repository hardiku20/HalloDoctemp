using System;
using System.Collections.Generic;

namespace learning1.DBEntities.Models;

public partial class TimesheetReimbursement
{
    public int TimesheetReimbursementId { get; set; }

    public int TimesheetId { get; set; }

    public string Item { get; set; } = null!;

    public int Amount { get; set; }

    public string? Bill { get; set; }

    public DateOnly ShiftDate { get; set; }

    public virtual Timesheet Timesheet { get; set; } = null!;
}
