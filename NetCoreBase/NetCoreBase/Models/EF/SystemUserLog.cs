using System;
using System.Collections.Generic;

namespace NetCoreBase.Models.EF;

public partial class SystemUserLog
{
    public int LogId { get; set; }

    public int AccountId { get; set; }

    public DateTime? LogDateTime { get; set; }

    public string Ip { get; set; } = null!;

    public string LogItem { get; set; } = null!;

    public string LogType { get; set; } = null!;

    public string Memo { get; set; } = null!;
}
