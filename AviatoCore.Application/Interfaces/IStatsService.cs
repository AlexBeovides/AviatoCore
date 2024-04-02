using AviatoCore.Application.DTOs;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IStatsService
    {
        Task<IActionResult> GetRepairServicesAsync();
        Task<IActionResult> GetMajorRepairsCountAsync();
        Task<IActionResult> GetCustomersByTypeAsync();
        Task<IActionResult> GetLeastVisitedSince2010Async();
        Task<IActionResult> GetAverageRepairCostAsync();
    }
}
