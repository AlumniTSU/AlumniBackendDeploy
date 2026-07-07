using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.File;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Results;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly AlumniDBContext _context;

        public FileRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<Entities.File?> GetByGuidAsync(Guid guid)
        {
            return await _context.Files.FirstOrDefaultAsync(f => f.ContentGuid == guid);
        }

        public async Task<AddFileResult> AddFileAsync(AddFileDto dto)
        {
            return await _context.AddFileAsync(dto);
        }
    }
}