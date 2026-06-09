using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

using backend.Dtos.User;
using backend.Mappers;
using Microsoft.AspNetCore.Identity;
using backend.Entities;
using System.Diagnostics;


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task RegisterAsync(RegisterUserDto userDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);

            if(existingUser != null)
            {
                throw new Exception("Email already exists");
            }
            
            var userModel = userDto.FromRegisterToUser();

            //var sw = Stopwatch.StartNew();
            await _userRepository.AddAsync(userModel);
            //Console.WriteLine($"register: {sw.ElapsedMilliseconds} ms");
        }

        public async Task<string?> LoginAsync(LoginUserDto userDto)
        {
            var user = await _userRepository.GetByEmailAsync(userDto.Email);

            if(user == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, userDto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.UserId.ToString()
                ),

                new Claim(
                    ClaimTypes.Email,
                    user.Email
                ),

                new Claim(
                    ClaimTypes.Name,
                    user.FirstName
                ),

                new Claim(
                    ClaimTypes.Surname,
                    user.LastName
                ),

                new Claim(
                    ClaimTypes.Role,
                    user.RoleId.ToString()
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["JWT:SigningKey"]!
                )
            );

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}