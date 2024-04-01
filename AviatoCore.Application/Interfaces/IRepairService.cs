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
        Task<RepairDto> GetRepairAsync(int id);
        Task<IEnumerable<RepairDto>> GetAllRepairsAsync();
        Task AddRepairAsync(RepairDto repairDto);
        Task UpdateRepairAsync(RepairDto repairDto);
        Task DeleteRepairAsync(int id);
    }
}
