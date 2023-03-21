using System;
using System.Collections.Generic;

namespace CallLogTesting.Models;

public partial class Hd
{
    public int Fccid { get; set; }

    public string Callsign { get; set; } = null!;

    public string? Status { get; set; }
}
