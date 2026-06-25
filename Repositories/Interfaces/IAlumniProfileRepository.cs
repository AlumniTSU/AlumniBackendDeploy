using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IAlumniProfileRepository
    {
        Task<AlumniProfile?> GetByUserIdAsync(int userId);
        Task UpdateAsync(AlumniProfile profile);
        Task AddAsync(AlumniProfile profile);
    }
}