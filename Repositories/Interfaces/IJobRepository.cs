using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Job;
using backend.Entities;
using backend.Results.Jobs;

namespace backend.Repositories.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<GetJobAdvertisementsResult>> GetAllAsync(int languageId, int advertisementTypeId);
        Task<AddJobAdvertisementResult> AddAsync(CreateJobAdvertisementDto dto, int userId);
    }
}