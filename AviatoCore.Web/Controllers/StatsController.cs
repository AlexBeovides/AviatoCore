using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Application.Services;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RTools_NTS.Util;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AviatoCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;
    
        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("repairServices")]
        public async Task<IActionResult> GetRepairServices()
        {
            return await _statsService.GetRepairServicesAsync();

        }
        [HttpGet("majorRepairsCount")]
        public async Task<IActionResult> GetMajorRepairsCount()
        {
            return await _statsService.GetMajorRepairsCountAsync();

        }
        [HttpGet("customersByType")]
        public async Task<IActionResult> GetCustomersByType()
        {
            return await _statsService.GetCustomersByTypeAsync();

        }
        [HttpGet("leastVisitedSince2010")]
        public async Task<IActionResult> GetLeastVisitedSince2010()
        {
            return await _statsService.GetLeastVisitedSince2010Async();

        }
        [HttpGet("averageRepairCost")]
        public async Task<IActionResult> GetAverageRepairCost()
        {
            return await _statsService.GetAverageRepairCostAsync();

        }
    }
}
