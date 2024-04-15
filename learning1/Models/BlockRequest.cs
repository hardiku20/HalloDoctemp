using System;
using System.Collections.Generic;

namespace learning1.Models;

public partial class BlockRequest
{
    public int BlockRequestId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }

    public string? Reason { get; set; }

    public string? Ip { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int RequestId { get; set; }

    public virtual Request Request { get; set; } = null!;
}
