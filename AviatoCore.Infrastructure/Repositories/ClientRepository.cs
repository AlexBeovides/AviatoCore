using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AviatoDbContext _context;

        public ClientRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientAsync(string id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(p => p.ClientId == id);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found");
            }
            return client;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Set<Client>().ToListAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            await _context.Set<Client>().AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Set<Client>().Update(client);
            await _context.SaveChangesAsync();
        }
    }
}