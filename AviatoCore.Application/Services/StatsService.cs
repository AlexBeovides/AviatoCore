using AviatoCore.Application.DTOs;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    // StatsService.cs
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;

        public StatsService(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        public async Task<IActionResult> GetRepairServicesAsync()
        {
            var result = await _statsRepository.GetRepairServicesAsync();
            return new OkObjectResult(result);
        }

        public async Task<IActionResult> GetMajorRepairsCountAsync()
        {
            var result = await _statsRepository.GetMajorRepairsCountAsync();
            return new OkObjectResult(result);
        }

        public async Task<IActionResult> GetCustomersByTypeAsync()
        {
            var result = await _statsRepository.GetCustomersByTypeAsync();
            return new OkObjectResult(result);
        }

        public async Task<IActionResult> GetLeastVisitedSince2010Async()
        {
            var result = await _statsRepository.GetLeastVisitedSince2010Async();
            return new OkObjectResult(result);
        }

        public async Task<IActionResult> GetAverageRepairCostAsync()
        {
            var result = await _statsRepository.GetAverageRepairCostAsync();
            return new OkObjectResult(result);
        }
    }
}
