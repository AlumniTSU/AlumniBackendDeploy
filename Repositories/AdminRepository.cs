using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Results.Statistics;

namespace backend.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AlumniDBContext _context;
        public AdminRepository(AlumniDBContext context)
        {
            _context = context;
        }
        
        
        public async Task<StatisticsResult?> GetStatisticsAsync(
    DateTime? fromDate,
    DateTime? toDate)
{
    var statistics = await _context
        .GetStatistics(fromDate, toDate)
        .ToListAsync();

    return statistics.SingleOrDefault();
}
    }
}