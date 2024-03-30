using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AirportsController : ControllerBase
{
    private readonly IAirportService _airportService;

    public AirportsController(IAirportService airportService)
    {
        _airportService = airportService;
    }

    // GET: api/Airports 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
    {
        return Ok(await _airportService.GetAllAirportsAsync());
    }

    // GET: api/Airports/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Airport>> GetAirport(int id)
    {
        var airport = await _airportService.GetAirportAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        return airport;
    }

    // PUT: api/Airports/5
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAirport(int id, Airport airport)
    {
        if (id != airport.Id)
        {
            return BadRequest();
        }

        await _airportService.UpdateAirportAsync(airport);

        return NoContent();
    }

    // POST: api/Airports
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Airport>> PostAirport(Airport airport)
    {
        await _airportService.AddAirportAsync(airport);

        return CreatedAtAction("GetAirport", new { id = airport.Id }, airport);
    }

    // DELETE: api/Airports/5
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirport(int id)
    {
        await _airportService.DeleteAirportAsync(id);

        return NoContent();
    }
}