using System;
using System.Collections.Generic;

namespace learning1.DBEntities.Models;

public partial class RequestType
{
    public int RequestTypeId { get; set; }

    public string Name { get; set; } = null!;
}
