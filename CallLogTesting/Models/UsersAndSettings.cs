using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallLogTesting.Models
{
    public class UsersAndSettings
    {
        public int Id { get; set; }
        [StringLength(30)] public string UserName { get; set; } = string.Empty;
        [StringLength(30)] public string Password { get; set; } = string.Empty;
        public int NumberOfCallsToShow { get; set; } = 15;
        public int PriviousCallsToShow { get; set; } = 5;
        [StringLength(4)] public string DefaultMode { get; set; } = "SSB";
        public int DefaultPower { get; set; } = 100;
        [StringLength(20)] public string database { get; set; } = string.Empty;

    }
}
