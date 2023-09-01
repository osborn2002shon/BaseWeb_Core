using System;
using System.Collections.Generic;

namespace NetCoreBase.Models;

public partial class SystemMenu
{
    public int MenuId { get; set; }

    public string? GroupName { get; set; }

    public string? MenuName { get; set; }

    public string? MenuUrl { get; set; }

    public int? OrderByGroup { get; set; }

    public int? OrderByMenu { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsShow { get; set; }

    public string? Memo { get; set; }
}
