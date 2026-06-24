using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Student;

namespace backend.Services.Interfaces
{
    public interface IAlumniService
    {
        Task<List<AlumniDto>> GetAllAsync();
        Task<AlumniDto> GetByIdAsync(int id);
    }
}