using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly AviatoDbContext _context;

        public UserRepository(UserManager<User> userManager, AviatoDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(user => user.Client)
                .Include(user => user.Worker)
                .ToListAsync();
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await GetUserAsync(id);
            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}