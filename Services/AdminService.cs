using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Repositories;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using backend.Results.Statistics;

namespace backend.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepo;
        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<StatisticsResult?> GetStatisticsAsync(DateTime? fromDate, DateTime? toDate)
        {
            return await _adminRepo.GetStatisticsAsync(fromDate, toDate);
        }
    }
}