using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.DTOs
{
    public class AirportServiceCountDto
    {
        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public int ServicesCount { get; set; }
    }
}
