using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Dtos.User;

namespace backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginUserDto dto);

        Task RegisterAsync(RegisterUserDto dto);

        
        
    }
}