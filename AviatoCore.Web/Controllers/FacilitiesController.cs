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

    // GET: api/Facilities 
    [Authorize(Roles = "Director")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Facility>>> GetFacilitiesByAirportId()
    {
        return Ok(await _facilityService.GetFacilitiesByAirportIdAsync(UserAirportId));
    }

    // GET: api/Facilities 
    [Authorize(Roles = "Client")]
    [HttpGet("WithType/{airportId}")]
    public async Task<ActionResult<IEnumerable<FacilityDto>>> GetFacilitiesByAirportIdWithFacType(int airportId)
    {
        return Ok(await _facilityService.GetFacilitiesByAirportIdWithFacTypeAsync(airportId));
    }

    // GET: api/Facilities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Facility>> GetFacility(int id)
    {
        var facility = await _facilityService.GetFacilityAsync(id, UserAirportId);

        if (facility == null)
        {
            return NotFound();
        }

        return facility;
    }

    // PUT: api/Facilities/5
    [Authorize(Roles = "Director")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFacility(int id, Facility facility)
    {
        if (id != facility.Id || UserAirportId != facility.AirportId)
        {
            return BadRequest();
        }

        await _facilityService.UpdateFacilityAsync(facility);

        return NoContent();
    }

    // POST: api/Facilities
    [Authorize(Roles = "Director")]
    [HttpPost]
    public async Task<ActionResult<Facility>> PostFacility(Facility facility)
    {
        if (UserAirportId != facility.AirportId)
        {
            return BadRequest();
        }

        await _facilityService.AddFacilityAsync(facility);

        return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
    }

    // DELETE: api/Facilities/5
    [Authorize(Roles = "Director")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFacility(int id)
    {
        var facility = await _facilityService.GetFacilityAsync(id, UserAirportId);   // ?

        if (facility == null || facility.AirportId != UserAirportId)
        {
            return Unauthorized();
        }

        await _facilityService.DeleteFacilityAsync(id);

        return NoContent();
    }
}