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
    public class RepairsController : Controller
    {
        private readonly IRepairService _repairService;

        public RepairsController(IRepairService repairService)
        {
            _repairService = repairService;
        }
        private int UserAirportId
        {
            get
            {
                var airportIdValue = User.FindFirstValue("UserAirportId");
                if (string.IsNullOrEmpty(airportIdValue))
                {
                    throw new Exception("UserAirportId is missing");
                }

                return int.Parse(airportIdValue);
            }
        }

        // GET: api/Repairs 
        [Authorize(Roles = "Maintenance")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetRepairs()
        {
            
            return Ok(await _repairService.GetRepairsByAirportIdAsync(UserAirportId));
        }

        // GET: api/Repairs/5
        [Authorize(Roles = "Maintenance")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairDto>> GetRepair(int id)
        {
            var repair = await _repairService.GetRepairAsync(id, UserAirportId);

            if (repair == null)
            {
                return NotFound();
            }

            return repair;
        }

        // PUT: api/Repairs/5
        [Authorize(Roles = "Maintenance")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepair(int id, RepairDto repair)
        {
            if (id != repair.Id)
            {
                return BadRequest();
            }

            await _repairService.UpdateRepairAsync(repair, UserAirportId);

            return NoContent();
        }

        // POST: api/Repairs
        [Authorize(Roles = "Maintenance")]
        [HttpPost]
        public async Task<ActionResult<RepairDto>> PostRepair(RepairDto repair)
        {
            await _repairService.AddRepairAsync(repair, UserAirportId);
            return CreatedAtAction(nameof(GetRepair), new { id = repair.Id }, repair);
        }

        // DELETE: api/Repairs/5
        [Authorize(Roles = "Maintenance")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            await _repairService.DeleteRepairAsync(id, UserAirportId);

            return NoContent();
        }
    }
}