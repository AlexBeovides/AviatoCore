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
        public async Task<IActionResult> Register(string email, string password, string name, string surname, string country)
        {
            var result = await _accountService.Register(email, password, name, surname, country);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(x => x.Description);
            return BadRequest(errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-worker")]
        public async Task<IActionResult> AddWorker(string email, string password, string name, string surname, string role, int airportId)
        {
            var result = await _accountService.AddWorker(email, password, name, surname, role, airportId);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(x => x.Description);
            return BadRequest(errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _accountService.Login(username, password);

            if (token != null)
            {
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
