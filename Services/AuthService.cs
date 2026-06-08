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

            await _userRepository.AddAsync(userModel);
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

            return "TEMP_TOKEN";
        }
    }
}