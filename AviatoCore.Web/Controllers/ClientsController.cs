using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Application.Services;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RTools_NTS.Util;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AviatoCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
    
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Clients 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAirports()
        {
            return Ok(await _clientService.GetAllClientsAsync());
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetFacility(string id)
        {
            var client = await _clientService.GetClientAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(string id, ClientDto client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            await _clientService.UpdateClientAsync(client);

            return NoContent();
        }

        // POST: api/Clients
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ClientDto>> PostClient(ClientDto client)
        {
            await _clientService.AddClientAsync(client);

            return Ok(client);
        }

        // DELETE: api/Clients/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            await _clientService.DeleteClientAsync(id);

            return NoContent();
        }
    }
}
