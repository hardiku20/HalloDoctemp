﻿using System;
using System.Collections.Generic;

namespace learning1.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Name { get; set; } = null!;

    public short AccountType { get; set; }

    public int? SortOrder { get; set; }

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
