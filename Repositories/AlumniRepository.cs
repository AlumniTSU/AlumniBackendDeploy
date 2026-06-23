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
            return await _context.AlumniProfiles
                .Include(a => a.User)
                .Select(a => new AlumniDto
                {
                    UserId = a.User.UserId,
                    FirstName = a.User.LastName,
                    Email = a.User.Email,
                    PhoneNumber = a.User.PhoneNumber,
                    Bio = a.Bio,
                    ContactEmail = a.ContactEmail,
                    ContactPhoneNumber = a.ContactPhoneNumber
                }).ToListAsync();
        }
    }
}