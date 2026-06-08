using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using backend.Dtos.User;
using backend.Entities;

namespace backend.Mappers
{
    public static class UserMappers
    {
        public static User FromRegisterToUser(this RegisterUserDto userDto)
        {
            var passwordHasher = new PasswordHasher<User>();
            
            return new User
            {
                PersonalId = userDto.PersonalId,
                PhoneNumber = userDto.PhoneNumber,
                FirstName = userDto.Name,
                LastName = userDto.Surname,
                Email = userDto.Email,
                HashedPassword = passwordHasher.HashPassword(null!, userDto.Password),
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}