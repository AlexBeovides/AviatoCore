using AviatoCore.Application.DTOs;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IClientService
    {
        Task<ClientDto> GetClientAsync(string id);
        Task<IEnumerable<ClientDto>> GetAllClientsAsync();
        Task<IdentityResult> AddClientAsync(ClientDto airport);
        Task UpdateClientAsync(ClientDto airport);
        Task DeleteClientAsync(string id);
    }
}
