using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
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

    // GET: api/Services 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices()
    {
        var services = await _serviceService.GetServicesByAirportIdAsync(UserAirportId);
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
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _serviceService.GetServiceAsync(id, UserAirportId);

        if (service == null)
        {
            return NotFound();
        }

        return service;
    }

    // PUT: api/Services/5
    [Authorize(Roles = "Director")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutService(int id, ServiceDto serviceDto)
    {
        var service = new Service
        {
            Id = serviceDto.Id,
            Name = serviceDto.Name,
            Description = serviceDto.Description,
            ImgUrl = serviceDto.ImgUrl,
            Price = serviceDto.Price,
            FacilityId = serviceDto.FacilityId,
            IsDeleted = serviceDto.IsDeleted
        };

        await _serviceService.UpdateServiceAsync(service, UserAirportId);

        return NoContent();
    }

    // POST: api/Services
    [Authorize(Roles = "Director")]
    [HttpPost]
    public async Task<ActionResult<Service>> PostService(ServiceDto serviceDto)
    {
        var service = new Service
        {
            Id = serviceDto.Id,
            Name = serviceDto.Name,
            Description = serviceDto.Description,
            ImgUrl = serviceDto.ImgUrl,
            Price = serviceDto.Price,
            FacilityId = serviceDto.FacilityId,
            IsDeleted = serviceDto.IsDeleted
        };

        await _serviceService.AddServiceAsync(service, UserAirportId);

        serviceDto.Id = service.Id; // Assuming AddServiceAsync sets the Id of the service

        return CreatedAtAction("GetService", new { id = serviceDto.Id }, serviceDto);
    }

    // DELETE: api/Services/5
    [Authorize(Roles = "Director")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _serviceService.GetServiceAsync(id, UserAirportId);

        await _serviceService.DeleteServiceAsync(id);

        return NoContent();
    }
}