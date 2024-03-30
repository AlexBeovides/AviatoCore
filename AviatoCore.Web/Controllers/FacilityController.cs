using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
    {
        return Ok(await _facilityService.GetAllFacilitiesAsync());
    }

    // GET: api/Facilities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Facility>> GetFacility(int id)
    {
        var facility = await _facilityService.GetFacilityAsync(id);

        if (facility == null)
        {
            return NotFound();
        }

        return facility;
    }

    // PUT: api/Facilities/5
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFacility(int id, Facility facility)
    {
        if (id != facility.Id)
        {
            return BadRequest();
        }

        await _facilityService.UpdateFacilityAsync(facility);

        return NoContent();
    }

    // POST: api/Facilities
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Facility>> PostFacility(Facility facility)
    {
        await _facilityService.AddFacilityAsync(facility);

        return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
    }

    // DELETE: api/Facilities/5
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFacility(int id)
    {
        await _facilityService.DeleteFacilityAsync(id);

        return NoContent();
    }
}