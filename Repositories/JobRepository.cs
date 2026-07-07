using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Results.Jobs;
using backend.Dtos.Job;

using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AlumniDBContext _context;
        public JobRepository(AlumniDBContext context)
        {
            _context = context;
        }

        
        
        public async Task<IEnumerable<GetJobAdvertisementsResult>> GetAllAsync(int languageId, int advertisementTypeId)
        {
            return await _context.GetJobAdvertisements(languageId, advertisementTypeId).ToListAsync();
        }

        public async Task<AddJobAdvertisementResult> AddAsync(
    CreateJobAdvertisementDto dto,
    int userId)
{
    return await _context.AddJobAdvertisementAsync(dto, userId);
}
        
        
    }
}