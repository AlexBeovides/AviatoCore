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
    public interface IAccountService
    {
        Task<IdentityResult> AddWorker(WorkerDto workerDto);
        Task<IdentityResult> Register(RegisterDto registerDto);
        Task<LoginResult> Login(LoginDto loginDto);

    }
}
