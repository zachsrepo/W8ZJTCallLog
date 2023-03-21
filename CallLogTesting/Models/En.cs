using System;
using System.Collections.Generic;

namespace CallLogTesting.Models;

public partial class En
{
    public int Fccid { get; set; }

    public string Callsign { get; set; } = null!;

    public string? FullName { get; set; }

    public string? First { get; set; }

    public string? Middle { get; set; }

    public string? Last { get; set; }

    public string? Address1 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }
}
