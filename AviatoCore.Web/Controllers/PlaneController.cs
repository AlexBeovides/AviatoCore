using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PlanesController : ControllerBase
{
    private readonly IPlaneService _planeService;

    public PlanesController(IPlaneService planeService)
    {
        _planeService = planeService;
    }

    // GET: api/Planes 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plane>>> GetPlanes()
    {
        return Ok(await _planeService.GetAllPlanesAsync());
    }

    // GET: api/Planes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Plane>> GetPlane(int id)
    {
        var plane = await _planeService.GetPlaneAsync(id);

        if (plane == null)
        {
            return NotFound();
        }

        return plane;
    }

    // PUT: api/Planes/5
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlane(int id, Plane plane)
    {
        if (id != plane.Id)
        {
            return BadRequest();
        }

        await _planeService.UpdatePlaneAsync(plane);

        return NoContent();
    }

    // POST: api/Planes
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Plane>> PostPlane(Plane plane)
    {
        await _planeService.AddPlaneAsync(plane);

        return CreatedAtAction("GetPlane", new { id = plane.Id }, plane);
    }

    // DELETE: api/Planes/5
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlane(int id)
    {
        await _planeService.DeletePlaneAsync(id);

        return NoContent();
    }
}