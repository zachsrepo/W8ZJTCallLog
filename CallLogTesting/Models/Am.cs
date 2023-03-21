using System;
using System.Collections.Generic;

namespace CallLogTesting.Models;

public partial class Am
{
    public int Fccid { get; set; }

    public string Callsign { get; set; } = null!;

    public string? Class { get; set; }

    public string? Col4 { get; set; }

    public string? Col5 { get; set; }

    public string? Col6 { get; set; }

    public string? FormerCall { get; set; }

    public string? FormerClass { get; set; }
}
