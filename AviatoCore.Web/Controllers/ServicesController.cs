using AviatoCore.Application.DTOs;
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
    private readonly IFacilityService _facilityService;

    public ServicesController(IServiceService serviceService,
        IFacilityService facilityService)
    {
        _serviceService = serviceService;
        _facilityService = facilityService;
    }

    // GET: api/Services 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices([FromQuery] int airportId)
    {
        var services = await _serviceService.GetServicesByAirportIdAsync(airportId);
        return Ok(services);
    }

    // GET: api/Services 
    [HttpGet("Facility/{facilityId}")]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServicesByFacId(int facilityId)
    {
        var services = await _serviceService.GetServicesByFacIdAsync(facilityId);
        return Ok(services);
    }

    // GET: api/Services/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(int id, [FromQuery] int airportId)
    {
        var service = await _serviceService.GetServiceAsync(id, airportId);

        if (service == null)
        {
            return NotFound();
        }

        return service;
    }



    // PUT: api/Services/5
    [Authorize(Roles = "Director")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutService(int id, [FromQuery] int airportId, ServiceDto serviceDto)
    {
        var service = new Service
        {
            Id = serviceDto.Id,
            Name = serviceDto.Name,
            Price = serviceDto.Price,
            FacilityId = serviceDto.FacilityId,
            IsDeleted = serviceDto.IsDeleted
        };

        await _serviceService.UpdateServiceAsync(service, airportId);

        return NoContent();
    }

    // POST: api/Services
    [Authorize(Roles = "Director")]
    [HttpPost]
    public async Task<ActionResult<Service>> PostService([FromQuery] int airportId, ServiceDto serviceDto)
    {
        var service = new Service
        {
            Id = serviceDto.Id,
            Name = serviceDto.Name,
            Price = serviceDto.Price,
            FacilityId = serviceDto.FacilityId,
            IsDeleted = serviceDto.IsDeleted
        };

        await _serviceService.AddServiceAsync(service, airportId);

        serviceDto.Id = service.Id; // Assuming AddServiceAsync sets the Id of the service

        return CreatedAtAction("GetService", new { id = serviceDto.Id }, serviceDto);
    }

    // DELETE: api/Services/5
    [Authorize(Roles = "Director")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id, [FromQuery] int airportId)
    {
        var service = await _serviceService.GetServiceAsync(id, airportId);

        await _serviceService.DeleteServiceAsync(id);

        return NoContent();
    }
}