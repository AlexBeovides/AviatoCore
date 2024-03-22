using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> AddWorker(string email, string password, string name, string surname, string role, int airportId);
        Task<IdentityResult> Register(string email, string password, string name, string surname, string country);
        Task<string> Login(string username, string password); 
    }
}
