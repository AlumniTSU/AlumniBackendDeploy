using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Student;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class AlumniService : IAlumniService
    {
        private readonly IAlumniRepository _alumniContext;

        public AlumniService(IAlumniRepository alumniContext)
        {
            _alumniContext = alumniContext;
        }

        public async Task<List<AlumniDto>> GetAllAsync()
        {
            return await _alumniContext.GetAllAsync();
        }

        public async Task<AlumniDto?> GetByIdAsync(int id)
        {
            return await _alumniContext.GetByIdAsync(id);
        }
    }
}