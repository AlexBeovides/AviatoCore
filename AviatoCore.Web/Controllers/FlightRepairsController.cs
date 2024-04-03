using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FlightRepairsController : ControllerBase
{
    private readonly IFlightRepairService _flightRepairService;
    private readonly IRepairService _repairService;

    public FlightRepairsController(IFlightRepairService flightRepairService
        , IRepairService repairService)
    {
        _flightRepairService = flightRepairService;
        _repairService = repairService;
    }

    // GET: api/FlightRepairs 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlightRepair>>> GetFlightRepairs()
    {
        return Ok(await _flightRepairService.GetAllFlightRepairsAsync());
    }

    // GET: api/FlightRepairs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FlightRepair>> GetFlightRepair(int id)
    {
        var flightRepair = await _flightRepairService.GetFlightRepairAsync(id);

        if (flightRepair == null)
        {
            return NotFound();
        }

        return flightRepair;
    }

    // PUT: api/FlightRepairs/5
    [Authorize(Roles = "Maintenance")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFlightRepair(int id, FlightRepair flightRepair)
    {
        if (id != flightRepair.Id)
        {
            return BadRequest();
        }

        await _flightRepairService.UpdateFlightRepairAsync(flightRepair);

        return NoContent();
    }

    // POST: api/FlightRepairs
    [Authorize(Roles = "Maintenance")]
    [HttpPost]
    public async Task<ActionResult<FlightRepair>> PostFlightRepair(FlightRepair flightRepair)
    {
        await _flightRepairService.AddFlightRepairAsync(flightRepair);

        return CreatedAtAction("GetFlightRepair", new { id = flightRepair.Id }, flightRepair);
    }

    // DELETE: api/FlightRepairs/5
    [Authorize(Roles = "Maintenance")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlightRepair(int id)
    {
        await _flightRepairService.DeleteFlightRepairAsync(id);

        return NoContent();
    }
}