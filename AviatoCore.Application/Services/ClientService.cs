using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly AviatoDbContext _context;

        public ClientService(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<bool> UpdateClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return false;
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<Client> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return false;
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
