using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Results.Statistics;

namespace backend.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<StatisticsResult?> GetStatisticsAsync(DateTime? fromDate, DateTime? toDate);
    }
}