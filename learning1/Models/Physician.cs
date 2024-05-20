using System;
using System.Collections.Generic;

namespace learning1.Models;

public partial class Physician
{
    public int PhysicianId { get; set; }

    public string? AspNetUserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? MedicalLicense { get; set; }

    public string? Photo { get; set; }

    public string? AdminNotes { get; set; }

    public bool? IsAgreementDoc { get; set; }

    public bool? IsBackgroundDoc { get; set; }

    public bool? IsTrainingDoc { get; set; }

    public bool? IsNonDisclosureDoc { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public int? RegionId { get; set; }

    public string? Zip { get; set; }

    public string? AltPhone { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public short? Status { get; set; }

    public string BusinessName { get; set; } = null!;

    public string BusinessWebsite { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public int? RoleId { get; set; }

    public string? Npinumber { get; set; }

    public bool? IsLicenseDoc { get; set; }

    public string? Signature { get; set; }

    public bool? IsCredentialDoc { get; set; }

    public bool? IsTokenGenerate { get; set; }

    public string? SyncEmailAddress { get; set; }

    public virtual AspNetUser? AspNetUser { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    public virtual ICollection<Payrate> Payrates { get; set; } = new List<Payrate>();

    public virtual ICollection<PhysicianLocation> PhysicianLocations { get; set; } = new List<PhysicianLocation>();

    public virtual ICollection<PhysicianNotification> PhysicianNotifications { get; set; } = new List<PhysicianNotification>();

    public virtual ICollection<PhysicianRegion> PhysicianRegions { get; set; } = new List<PhysicianRegion>();

    public virtual ICollection<RequestStatusLog> RequestStatusLogPhysicians { get; set; } = new List<RequestStatusLog>();

    public virtual ICollection<RequestStatusLog> RequestStatusLogTransToPhysicians { get; set; } = new List<RequestStatusLog>();

    public virtual ICollection<RequestWiseFile> RequestWiseFiles { get; set; } = new List<RequestWiseFile>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
