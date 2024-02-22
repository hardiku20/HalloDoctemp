using System;
using System.Collections.Generic;

namespace learning1.DBEntities.Models;

public partial class CaseTag
{
    public int CaseTagId { get; set; }

    public string Name { get; set; } = null!;
}
