using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Results.Statistics;

namespace backend.Services.Interfaces
{
    public interface IAdminService
    {
        Task<StatisticsResult?> GetStatisticsAsync(DateTime? fromDate, DateTime? toDate);
    }
}