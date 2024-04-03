using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Application.Services;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ServiceRequestsController : ControllerBase
{
    private readonly IServiceRequestService _serviceRequestService;

    public ServiceRequestsController(IServiceRequestService serviceRequestService)
    {
        _serviceRequestService = serviceRequestService;
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

    // GET: api/ServiceRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
    {
        var serviceRequest = await _serviceRequestService.GetServiceRequestAsync(id);

        if (serviceRequest == null)
        {
            return NotFound();
        }

        return serviceRequest;
    }

    // GET: api/ServiceRequests/Airport/5
    [Authorize(Roles = "Director")]
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequestsByAirportId()
    {
        var serviceRequests = await _serviceRequestService.GetServiceRequestsByAirportIdAsync(UserAirportId);

        if (serviceRequests == null)
        {
            return NotFound();
        }

        return Ok(serviceRequests);
    }

    // POST: api/ClientServices
    [Authorize(Roles = "Client")]
    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> PostServiceRequest([FromBody] ServiceRequestDto serviceRequestDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User identifier is missing");
        }

        var serviceRequest = new ServiceRequest
        {
            RequestedAt = DateTime.UtcNow, // Set RequestedAt to the current time
            ClientId = userId, // Set ClientId to the authenticated user's id
            ServiceId = serviceRequestDto.ServiceId // Set ServiceId to the provided serviceId
        };

        await _serviceRequestService.AddServiceRequestAsync(serviceRequest);

        return CreatedAtAction("GetServiceRequest", new { id = serviceRequest.Id }, serviceRequest);
    }

}