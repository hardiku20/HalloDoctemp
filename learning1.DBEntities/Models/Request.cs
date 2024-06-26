﻿using System;
using System.Collections.Generic;

namespace learning1.DBEntities.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public int RequestTypeId { get; set; }

    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public short Status { get; set; }

    public int? PhysicianId { get; set; }

    public string? ConfirmationNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? DeclinedBy { get; set; }

    public bool IsUrgentEmailSent { get; set; }

    public DateTime? LastWellnessDate { get; set; }

    public bool? IsMobile { get; set; }

    public short? CallType { get; set; }

    public bool? CompletedByPhysician { get; set; }

    public DateTime? LastReservationDate { get; set; }

    public DateTime? AcceptedDate { get; set; }

    public string? RelationName { get; set; }

    public string? CaseNumber { get; set; }

    public string? Ip { get; set; }

    public string? CaseTagPhysician { get; set; }

    public string? PatientAccountId { get; set; }

    public int? CreatedUserId { get; set; }

    public int? CaseTagId { get; set; }

    public virtual ICollection<BlockRequest> BlockRequests { get; set; } = new List<BlockRequest>();

    public virtual CaseTag? CaseTag { get; set; }

    public virtual ICollection<EncounterForm> EncounterForms { get; set; } = new List<EncounterForm>();

    public virtual Physician? Physician { get; set; }

    public virtual ICollection<RequestBusiness> RequestBusinesses { get; set; } = new List<RequestBusiness>();

    public virtual ICollection<RequestClient> RequestClients { get; set; } = new List<RequestClient>();

    public virtual ICollection<RequestClosed> RequestCloseds { get; set; } = new List<RequestClosed>();

    public virtual ICollection<RequestConcierge> RequestConcierges { get; set; } = new List<RequestConcierge>();

    public virtual ICollection<RequestNote> RequestNotes { get; set; } = new List<RequestNote>();

    public virtual ICollection<RequestStatusLog> RequestStatusLogs { get; set; } = new List<RequestStatusLog>();

    public virtual ICollection<RequestWiseFile> RequestWiseFiles { get; set; } = new List<RequestWiseFile>();

    public virtual User User { get; set; } = null!;
}
