using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController] 
public class ServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServicesController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    // GET: api/Services 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return Ok(await _serviceService.GetAllServicesAsync());
    }

    // GET: api/Services/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _serviceService.GetServiceAsync(id);

        if (service == null)
        {
            return NotFound();
        }

        return service;
    }

    // PUT: api/Services/5
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutService(int id, Service service)
    {
        if (id != service.Id)
        {
            return BadRequest();
        }

        await _serviceService.UpdateServiceAsync(service);

        return NoContent();
    }

    // POST: api/Services
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Service>> PostService(Service service)
    {
        await _serviceService.AddServiceAsync(service);

        return CreatedAtAction("GetService", new { id = service.Id }, service);
    }

    // DELETE: api/Services/5
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _serviceService.DeleteServiceAsync(id);

        return NoContent();
    }
}