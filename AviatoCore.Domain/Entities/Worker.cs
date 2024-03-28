using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Entities
{
    public class Worker
    {
        [Key]
        public string WorkerId { get; set; }
        public string UserId { get; set; } // Foreign key to User
        public int AirportId { get; set; }
        public User User { get; set; } // Navigation property
        public Airport Airport { get; set; }
    }
}
