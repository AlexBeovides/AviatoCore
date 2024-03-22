using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AviatoDbContext _context;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, AviatoDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IdentityResult> Register(string email, string password, string name, string surname, string country)
        {
            var user = new User
            {
                UserName = email,
                Name = name,
                Surname = surname
            };

            var admin = new User
            {
                UserName = "admin@admin.com",
                Name = "admin",
                Surname = "admin"
            };

            var rresult = await _userManager.CreateAsync(admin, "Admin_77");
            if (rresult.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(admin, "Admin");
                if (!roleResult.Succeeded)
                {
                    return IdentityResult.Failed(roleResult.Errors.ToArray());
                }
            }
            else
            {
                return IdentityResult.Failed(rresult.Errors.ToArray());
            }

            var result = await _userManager.CreateAsync(user, password);

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
                    Country = country,
                    ClientTypeId = 1
                };

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }

            return result;
        }
        public async Task<IdentityResult> AddWorker(string email, string password, string name, string surname, string role, int airportId)
        {
            var user = new User
            {
                UserName = email,
                Name = name,
                Surname = surname
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, role);
                if (!roleResult.Succeeded)
                {
                    return IdentityResult.Failed(roleResult.Errors.ToArray());
                }

                if(role != "Admin")
                {
                    var worker = new Worker
                    {
                        WorkerId = user.Id,
                        UserId = user.Id,
                        AirportId = airportId
                    };

                    _context.Workers.Add(worker);
                    await _context.SaveChangesAsync();
                }
            }

            return result;
        }
        private async Task<string> GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_secret_key_here_that_is_at_least_32_characters_long"); // Replace with your secret key
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName ?? string.Empty) };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Token expiration, adjust as needed
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return await GenerateJwtToken(user);
            }

            return string.Empty;
        }
    }
}
