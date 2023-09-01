using System;
using System.Collections.Generic;

namespace NetCoreBase.Models;

public partial class SystemTaiwan
{
    public int TwId { get; set; }

    public int CityId { get; set; }

    public string City { get; set; } = null!;

    public string Area { get; set; } = null!;
}
