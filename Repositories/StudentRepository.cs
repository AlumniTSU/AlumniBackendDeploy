using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AlumniDBContext _context;

        public StudentRepository(AlumniDBContext context)
        {
            _context = context;
        }
        
        public async Task<Student?> GetByPersonalIdAsync(string personalId)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.PersonalId == personalId);
        }
    }
}