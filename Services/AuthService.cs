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


namespace backend.Services
{
    public class AuthService : IAuthService
    {
        public readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterUserDto userDto)
        {
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

            
            //var sw = Stopwatch.StartNew();

            var result = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, userDto.Password);

            //Console.WriteLine($"Hash verification: {sw.ElapsedMilliseconds} ms");

            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return "TEMP_TOKEN";
        }
    }
}