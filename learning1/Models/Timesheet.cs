using System;
using System.Collections;
using System.Collections.Generic;

namespace learning1.Models;

public partial class Timesheet
{
    public int PhysicianId { get; set; }

    public int TimesheetId { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public BitArray? IsFinalized { get; set; }

    public bool? Status { get; set; }

    public virtual Physician Physician { get; set; } = null!;

    public virtual ICollection<TimesheetDetail> TimesheetDetails { get; set; } = new List<TimesheetDetail>();

    public virtual ICollection<TimesheetReimbursement> TimesheetReimbursements { get; set; } = new List<TimesheetReimbursement>();
}
