using AviatoCore.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    public interface IStatsRepository
    {
        Task<List<AirportRepairServiceDto>> GetRepairServicesAsync();
        Task<List<AirportMajorRepairCountDto>> GetMajorRepairsCountAsync();
        Task<List<AirportClientDto>> GetCustomersByTypeAsync();
        Task<List<AirportServiceCountDto>> GetLeastVisitedSince2010Async();
        Task<AirportInefficientRepairServiceDto> GetAverageRepairCostAsync();
    }
}
