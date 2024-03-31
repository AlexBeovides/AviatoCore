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
    public class WorkersController : Controller
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/Workers 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDto>>> GetWorkers()
        {
            return Ok(await _workerService.GetAllWorkersAsync());
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDto>> GetWorker(string id)
        {
            var worker = await _workerService.GetWorkerAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // PUT: api/Workers/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(string id, WorkerDto worker)
        {
            if (id != worker.Id)
            {
                return BadRequest();
            }

            await _workerService.UpdateWorkerAsync(worker);

            return NoContent();
        }

        // POST: api/Workers
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<WorkerDto>> PostWorker(WorkerDto worker)
        {
            var result = await _workerService.AddWorkerAsync(worker);

            if (result.Succeeded)
            {
                return Ok(worker);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        // DELETE: api/Workers/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(string id)
        {
            await _workerService.DeleteWorkerAsync(id);

            return NoContent();
        }
    }
}