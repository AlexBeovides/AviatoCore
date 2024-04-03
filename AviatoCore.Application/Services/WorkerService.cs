using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AviatoCore.Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly UserManager<User> _userManager; 

        public WorkerService(IUserRepository userRepository, 
            IWorkerRepository workerRepository,
            UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _workerRepository = workerRepository;
            _userManager = userManager;
        }

        public async Task<WorkerDto> GetWorkerAsync(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            var worker = await _workerRepository.GetWorkerAsync(id);

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();     

            return new WorkerDto
            {
                Id = user.Id,
                Email = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Role = role, 
                AirportId = worker.AirportId,
                IsDeleted = user.IsDeleted
            };
        }

        public async Task<IEnumerable<WorkerDto>> GetAllWorkersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            // Convert the users to a list
            var userList = users.ToList();

            // Create a list to store the WorkerDto objects
            var workerDtos = new List<WorkerDto>();

            foreach (var user in userList)
            {
                if (user.Worker != null)
                {
                    // Get the roles of the user
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();

                    // Create a WorkerDto object and add it to the list
                    workerDtos.Add(new WorkerDto
                    {
                        Id = user.Id,
                        Email = user.UserName,
                        Name = user.Name,
                        Role = role,
                        Surname = user.Surname,
                        AirportId = user.Worker.AirportId,
                        IsDeleted = user.IsDeleted
                    });
                }
            }

            return workerDtos;
        }

        public async Task<IdentityResult> AddWorkerAsync(WorkerDto workerDto)
        {
            var user = new User
            {
                UserName = workerDto.Email,
                Name = workerDto.Name,
                Surname = workerDto.Surname,
                IsDeleted = false
            };

            if(workerDto.Role=="Admin" || workerDto.Role == "Client")
            {
                throw new Exception();
            }

            var result = await _userRepository.AddUserAsync(user, workerDto.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, workerDto.Role);
                if (!roleResult.Succeeded)
                {
                    return IdentityResult.Failed(roleResult.Errors.ToArray());
                }

                var worker = new Worker
                {
                    WorkerId = user.Id,
                    UserId = user.Id,
                    AirportId = workerDto.AirportId
                };

                await _workerRepository.AddWorkerAsync(worker);
                return IdentityResult.Success;
            }
            else
            {
                // Handle the case where the user creation failed
                // You can throw an exception, log an error, or take any appropriate action
                throw new Exception(result.Errors.FirstOrDefault()?.Description);
            }
        }

        public async Task UpdateWorkerAsync(WorkerDto workerDto)
        {
            if (workerDto.Role == "Client" || workerDto.Role == "Admin")
            {
                throw new Exception();
            }

            var user = await _userRepository.GetUserAsync(workerDto.Id);
            var worker = await _workerRepository.GetWorkerAsync(workerDto.Id);
            var role = await _userManager.GetRolesAsync(user);

            if (role.Count > 0)
            {
                var roleString = role[0];
                await _userManager.RemoveFromRoleAsync(user, roleString);
            }

            user.UserName = workerDto.Email;
            user.Name = workerDto.Name;
            user.Surname = workerDto.Surname;
            user.IsDeleted = workerDto.IsDeleted;

            worker.AirportId = workerDto.AirportId;

            await _userRepository.UpdateUserAsync(user);
            await _workerRepository.UpdateWorkerAsync(worker);
            await _userManager.AddToRoleAsync(user,  workerDto.Role );
        }

        public async Task DeleteWorkerAsync(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
