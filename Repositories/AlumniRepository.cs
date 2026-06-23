using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Dtos.Alumni;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class AlumniRepository : IAlumniRepository
    {
        private readonly AlumniDBContext _context;

        public AlumniRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<List<AlumniDto>> GetAllAsync()
        {
            return await _context.Students.Where(s => s.HasUniversityFinished).Select(s => new AlumniDto
            {
                StudentId = s.StudentId,
                StudentFirstname = s.StudentFirstName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber
            }).ToListAsync();
        }
    }
}