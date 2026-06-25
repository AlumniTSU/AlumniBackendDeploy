using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class AlumniProfileRepository : IAlumniProfileRepository
    {
        private readonly AlumniDBContext _context;
        public AlumniProfileRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<AlumniProfile?> GetByUserIdAsync(int userId)
        {
            return await _context.AlumniProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task UpdateAsync(AlumniProfile profile)
        {
            _context.AlumniProfiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(AlumniProfile profile)
        {
            await _context.AlumniProfiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }
    }
}