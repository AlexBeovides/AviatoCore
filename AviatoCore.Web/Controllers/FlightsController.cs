using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    // GET: api/Flights 
    [Authorize(Roles = "Security,Maintenance")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Flight>>> GetFlightsByAirportId()
    {
        var airportIdValue = User.FindFirstValue("UserAirportId");

        if (string.IsNullOrEmpty(airportIdValue))
        {
            return BadRequest("UserAirportId is missing");
        }

        var airportId = int.Parse(airportIdValue);

        return Ok(await _flightService.GetFlightsByAirportIdAsync(airportId));
    }

    // GET: api/Flights/5
    [Authorize(Roles = "Security")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Flight>> GetFlight(int id)
    {
        var flight = await _flightService.GetFlightAsync(id);

        if (flight == null)
        {
            return NotFound();
        }

        return flight;
    }

    // PUT: api/Flights/5
    [Authorize(Roles = "Security")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFlight(int id, Flight flight)
    {
        if (id != flight.Id)
        {
            return BadRequest();
        }

        await _flightService.UpdateFlightAsync(flight);

        return NoContent();
    }

    // POST: api/Flights
    [Authorize(Roles = "Security")]
    [HttpPost]
    public async Task<ActionResult<Flight>> PostFlight(Flight flight)
    {
        var airportIdValue = User.FindFirstValue("UserAirportId");

        if (string.IsNullOrEmpty(airportIdValue))
        {
            return BadRequest("UserAirportId is missing");
        }

        var airportId = int.Parse(airportIdValue);
        flight.AirportId = airportId;
        await _flightService.AddFlightAsync(flight);

        return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
    }

    // DELETE: api/Flights/5
    [Authorize(Roles = "Security")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight(int id)
    {
        await _flightService.DeleteFlightAsync(id);

        return NoContent();
    }

    // PUT: api/Flights/CheckFlight/5
    [Authorize(Roles = "Security")]
    [HttpPut("/CheckFlight/{flightId}")]
    public async Task<IActionResult> CheckFlight(int flightId)
    {
        var flight = await _flightService.GetFlightAsync(flightId);

        var airportIdValue = User.FindFirstValue("UserAirportId");
        if (string.IsNullOrEmpty(airportIdValue))
        {
            return BadRequest("UserAirportId is missing");
        }

        var airportId = int.Parse(airportIdValue);

        if (flight.AirportId != airportId)
        {
            return Unauthorized();
        }

        flight.NeedsCheck = false;

        await _flightService.UpdateFlightAsync(flight);

        return NoContent();
    }
}