using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly UserManager<User> _userManager;

        public ClientService(IUserRepository userRepository,
            IClientRepository clientRepository,
            UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _userManager = userManager;
        }

        public async Task<ClientDto> GetClientAsync(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            var client = await _clientRepository.GetClientAsync(id);

            return new ClientDto
            {
                Id = user.Id,
                Email = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Country = client.Country,
                ClientTypeId = client.ClientTypeId,
                IsDeleted = user.IsDeleted
            };
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            // Count the number of users who are clients
            int clientCount = users.Count(user => user.Client != null);

            return users
                .Where(user => user.Client != null) // Only consider users who are clients
                .Select(user => new ClientDto
                {
                    Id = user.Id,
                    Email = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    Country = user.Client.Country,
                    ClientTypeId = user.Client.ClientTypeId,
                    IsDeleted = user.IsDeleted
                })
                .ToList();
        }

        public async Task<IdentityResult> AddClientAsync(ClientDto clientDto)
        {
            var user = new User
            {
                UserName = clientDto.Email,
                Name = clientDto.Name,
                Surname = clientDto.Surname,
                IsDeleted = false
            };

            var result = await _userRepository.AddUserAsync(user, clientDto.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Client");
                if (!roleResult.Succeeded)
                {
                    return IdentityResult.Failed(roleResult.Errors.ToArray());
                }

                var client = new Client
                {
                    ClientId = user.Id,
                    UserId = user.Id,
                    Country = clientDto.Country,
                    ClientTypeId = clientDto.ClientTypeId
                };

                await _clientRepository.AddClientAsync(client);
                return IdentityResult.Success;
            }
            else
            {
                // Handle the case where the user creation failed
                // You can throw an exception, log an error, or take any appropriate action
                throw new Exception(result.Errors.FirstOrDefault()?.Description);
            }
        }

        public async Task UpdateClientAsync(ClientDto clientDto)
        {
            var user = await _userRepository.GetUserAsync(clientDto.Id);
            var client = await _clientRepository.GetClientAsync(clientDto.Id);

            user.UserName = clientDto.Email;
            user.Name = clientDto.Name;
            user.Surname = clientDto.Surname;
            user.IsDeleted = clientDto.IsDeleted;

            client.Country = clientDto.Country;
            client.ClientTypeId = clientDto.ClientTypeId;

            await _userRepository.UpdateUserAsync(user);
            await _clientRepository.UpdateClientAsync(client);
        }

        public async Task DeleteClientAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}