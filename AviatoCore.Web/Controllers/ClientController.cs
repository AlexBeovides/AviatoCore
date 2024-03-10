using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // GET: api/Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return Ok(await _clientService.GetClients());
    }

    // GET: api/Clients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        var client = await _clientService.GetClient(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    // PUT: api/Clients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, Client client)
    {
        var result = await _clientService.UpdateClient(id, client);

        if (!result)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/Clients
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client client)
    {
        var createdClient = await _clientService.CreateClient(client);

        return CreatedAtAction("GetClient", new { id = createdClient.Id }, createdClient);
    }

    // DELETE: api/Clients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var result = await _clientService.DeleteClient(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}