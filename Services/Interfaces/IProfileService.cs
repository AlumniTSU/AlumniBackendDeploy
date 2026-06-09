using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Services.Interfaces
{
    public interface IProfileService
    {
        Task<User?> GetProfileAsync(int userId);
    }
}