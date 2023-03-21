using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Models
{
    public class Ham
    {
        public int Id { get; set; }
        [StringLength(30)] public string Callsign { get; set; } = string.Empty;
        [StringLength(30)] public string FirstName { get; set; } = string.Empty;
        [StringLength(30)] public string? LastName { get; set; }
        [StringLength(40)] public string? Country { get; set; }
        [StringLength(40)] public string? City { get; set; }
        [StringLength(2)] public string? State { get; set; }
        [StringLength(10)] public string? PostalCode { get; set; }
        [StringLength(100)] public string? Address { get; set; }

        public string? QTH { get; set; }
        public DateTime DateAndTime { get; set; }

        public Ham() { }

    }
}
