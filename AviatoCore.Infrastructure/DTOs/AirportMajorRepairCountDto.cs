using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.DTOs
{
    public class AirportMajorRepairCountDto
    {
        public string AirportName { get; set; }
                                                          
        public int CapitalRepairCount { get; set; }
    }
}