using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


using backend.Dtos.User;
using backend.Entities;
using backend.Mappers;
using backend.Repositories.Interfaces;

using backend.Services.Interfaces;

namespace backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // private readonly AlumniDBContext _context;
        private readonly IConfiguration _configuration;

        private readonly IAuthService _authService;        


        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }


        

        
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            // var userModel = userDto.FromRegisterToUser();
            // // await _context.Users.AddAsync(userModel);
            // // await _context.SaveChangesAsync();

            
            // await _userRepository.AddAsync(userModel);

            // return Ok();

            

            await _authService.RegisterAsync(userDto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            

            var token = await _authService.LoginAsync(userDto);

            if(token == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new {token});
        }


        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            // return Ok(new
            // {
            //     Message = "You are authenticated"
            // });

            return Ok(new
            {
                UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,

                Email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value,

                UserName = User.Identity?.Name
            });
        }
    }
}