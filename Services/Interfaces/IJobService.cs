using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Dtos.Job;
using backend.Results.Jobs;

namespace backend.Services.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<JobAdvertisementDto>> GetJobAdvertisementsAsync(int languageId, int advertisementTypeId);
        Task<AddJobAdvertisementResult> AddAsync(CreateJobAdvertisementDto dto, int userId);
    }
}