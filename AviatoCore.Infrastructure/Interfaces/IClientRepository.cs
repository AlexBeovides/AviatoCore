using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetClientAsync(string id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
    }
}
