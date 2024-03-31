using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Application.Services;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RTools_NTS.Util;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AviatoCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly AviatoDbContext _context;
        private readonly IAccountService _accountService;
    
        public AccountController(AviatoDbContext context, IAccountService accountService, 
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _accountService.Register(registerDto);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(x => x.Description);
            return BadRequest(errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-worker")]
        public async Task<IActionResult> AddWorker(WorkerDto workerDto)
        {
            var result = await _accountService.AddWorker(workerDto);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(x => x.Description);
            return BadRequest(errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var loginResult = await _accountService.Login(loginDto);

            if (loginResult != null)
            {
                return Ok(new { Token = loginResult.Token, Role = loginResult.Role ,
                    AirportId = loginResult.AirportId});
            }

            return Unauthorized();
        }
    }
}
