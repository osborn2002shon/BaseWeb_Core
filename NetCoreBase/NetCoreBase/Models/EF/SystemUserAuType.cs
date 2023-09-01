﻿using System;
using System.Collections.Generic;

namespace NetCoreBase.Models.EF;

public partial class SystemUserAuType
{
    public int AuTypeId { get; set; }

    public string AuTypeName { get; set; } = null!;

    public string? Memo { get; set; }
}
