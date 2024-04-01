using AviatoCore.Application.DTOs;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IRepairService
    {
        Task<RepairDto> GetRepairAsync(int id, int userAirportId);
        Task<IEnumerable<RepairDto>> GetRepairsByAirportIdAsync(int userAirportId);
        Task AddRepairAsync(RepairDto repairDto, int userAirportId);
        Task UpdateRepairAsync(RepairDto repairDto, int userAirportId);
        Task DeleteRepairAsync(int id, int userAirportId);
    }
}
