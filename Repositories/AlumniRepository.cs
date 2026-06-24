using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Dtos.Student;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Mappers;
using backend.Helpers;

namespace backend.Repositories
{
    public class AlumniRepository : IAlumniRepository
    {
        private readonly AlumniDBContext _context;

        public AlumniRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<List<AlumniDto>> GetAllAsync(QueryObject? search)
        {
            var query = _context.Students.AsNoTracking().Where(s => s.HasUniversityFinished);

            
            if (!string.IsNullOrWhiteSpace(search?.FirstName))
            {
                query = query.Where(s => s.StudentFirstName.Contains(search.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(search?.LastName))
            {
                query = query.Where(s => s.StudentLastName!.Contains(search.LastName));
            }

            int pageNumber = search?.PageNumber ?? 1;
            int pageSize = search?.PageSize ?? 20;

            int skipNumber = (pageNumber - 1) * pageSize;
             

             
            return await query
                .Skip(skipNumber)
                .Take(pageSize)
                .Select(s => s.ToAlumniDto()).ToListAsync();
        }

        public async Task<AlumniDto?> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.HasUniversityFinished && s.StudentId == id);

            if(student == null)
            {
                return null;
            }

            return student.ToAlumniDto();
        }
    }
}