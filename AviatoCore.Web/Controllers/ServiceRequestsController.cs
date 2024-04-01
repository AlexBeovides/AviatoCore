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

    // GET: api/ServiceRequests/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceRequest>> GetClientService(int id)
    {
        var serviceRequest = await _serviceRequestService.GetServiceRequestAsync(id);

        if (serviceRequest == null)
        {
            return NotFound();
        }

        return serviceRequest;
    }

    // POST: api/ClientServices
    [Authorize(Roles = "Client")]
    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> PostClientService([FromBody] ServiceRequestDto serviceRequestDto)
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

        return CreatedAtAction("GetClientService", new { id = serviceRequest.Id }, serviceRequest);
    }

}