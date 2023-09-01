using System;
using System.Collections.Generic;

namespace NetCoreBase.Models.EF;

public partial class SystemUserAccount
{
    public int AccountId { get; set; }

    public int AuTypeId { get; set; }

    public string Account { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Unit { get; set; }

    public string? Mobile { get; set; }

    public string? Memo { get; set; }

    public bool IsActive { get; set; }

    public DateTime InsertDateTime { get; set; }

    public int InsertAccountId { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public int? UpdateAccountId { get; set; }

    public DateTime? RemoveDateTime { get; set; }

    public int? RemoveAccountId { get; set; }

    public DateTime? LastUpdatePwdateTime { get; set; }
}
