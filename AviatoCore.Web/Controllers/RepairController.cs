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

        // GET: api/Repairs 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetRepairs()
        {
            return Ok(await _repairService.GetAllRepairsAsync());
        }

        // GET: api/Repairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairDto>> GetRepair(int id)
        {
            var repair = await _repairService.GetRepairAsync(id);

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

            await _repairService.UpdateRepairAsync(repair);

            return NoContent();
        }

        // POST: api/Repairs
        [Authorize(Roles = "Maintenance")]
        [HttpPost]
        public async Task<ActionResult<RepairDto>> PostRepair(RepairDto repair)
        {
            await _repairService.AddRepairAsync(repair);
            return CreatedAtAction(nameof(GetRepair), new { id = repair.Id }, repair);
        }

        // DELETE: api/Repairs/5
        [Authorize(Roles = "Maintenance")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            await _repairService.DeleteRepairAsync(id);

            return NoContent();
        }
    }
}