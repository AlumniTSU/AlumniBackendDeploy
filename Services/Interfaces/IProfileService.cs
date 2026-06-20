using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Profile;
using backend.Entities;

namespace backend.Services.Interfaces
{
    public interface IProfileService
    {
        Task<User?> GetProfileAsync(int userId);
        
        Task<bool> UpdateProfileAsync(int userId, UpdateProfileDto dto);

        Task<bool> UpdatePasswordAsync(int userId, UpdatePasswordDto dto);
    }
}