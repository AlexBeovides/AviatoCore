using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task <IdentityResult> AddUserAsync(User client , string password);
        Task UpdateUserAsync(User client);
        Task DeleteUserAsync(string id);
    }
}
