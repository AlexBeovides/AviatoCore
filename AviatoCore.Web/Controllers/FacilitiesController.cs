using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FacilitiesController : ControllerBase
{
    private readonly IFacilityService _facilityService;

    public FacilitiesController(IFacilityService facilityService)
    {
        _facilityService = facilityService;
    }

    // GET: api/Facilities 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities([FromQuery] int airportId)
    {
        return Ok(await _facilityService.GetFacilitiesByAirportIdAsync(airportId));
    }

    // GET: api/Facilities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Facility>> GetFacility(int id, [FromQuery] int airportId)
    {
        var facility = await _facilityService.GetFacilityAsync(id, airportId);

        if (facility == null)
        {
            return NotFound();
        }

        return facility;
    }

    // PUT: api/Facilities/5
    [Authorize(Roles = "Director")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFacility(int id, [FromQuery] int airportId, Facility facility)
    {
        if (id != facility.Id || airportId != facility.AirportId)
        {
            return BadRequest();
        }

        await _facilityService.UpdateFacilityAsync(facility);

        return NoContent();
    }

    // POST: api/Facilities
    [Authorize(Roles = "Director")]
    [HttpPost]
    public async Task<ActionResult<Facility>> PostFacility([FromQuery] int airportId, Facility facility)
    {
        if (airportId != facility.AirportId)
        {
            return BadRequest();
        }

        await _facilityService.AddFacilityAsync(facility);

        return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
    }

    // DELETE: api/Facilities/5
    [Authorize(Roles = "Director")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFacility(int id, [FromQuery] int airportId)
    {
        var facility = await _facilityService.GetFacilityAsync(id, airportId);

        if (facility == null || facility.AirportId != airportId)
        {
            return Unauthorized();
        }

        await _facilityService.DeleteFacilityAsync(id);

        return NoContent();
    }
}