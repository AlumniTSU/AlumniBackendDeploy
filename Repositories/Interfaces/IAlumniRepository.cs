using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Student;
using backend.Helpers;

namespace backend.Repositories.Interfaces
{
    public interface IAlumniRepository
    {
        Task<List<AlumniDto>> GetAllAsync(QueryObject? search);
        Task<AlumniDto?> GetByIdAsync(int id);
    }
}