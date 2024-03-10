using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<bool> UpdateClient(int id, Client client);
        Task<Client> CreateClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}
