using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Job;
using backend.Mappers;
using backend.Repositories.Interfaces;
using backend.Results.Jobs;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepo;

        public JobService(IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;
        }

        public async Task<IEnumerable<JobAdvertisementDto>> GetJobAdvertisementsAsync(int languageId, int advertisementTypeId)
        {
            var jobs = await _jobRepo.GetAllAsync(languageId, advertisementTypeId);

            return jobs.Select(j => j.ToJobDto());
        }

        public async Task<AddJobAdvertisementResult> AddAsync(CreateJobAdvertisementDto dto, int userId)
        {
            return await _jobRepo.AddAsync(dto, userId);
        }

        public async Task<JobAdvertisementDto?> GetByIdAsync(int languageId, int advertisementId)
        {
            var job = await _jobRepo.GetByIdAsync(languageId, advertisementId);

            if (job == null)
                return null;

            return job.ToJobDto();
        }

        public async Task<UpdateJobAdvertisementResult> UpdateAsync(int advertisementId, UpdateJobAdvertisementDto dto, int userId)
        {
            return await _jobRepo.UpdateAsync(advertisementId, dto,userId);
        }

        public async Task<DeleteJobAdvertisementResult> DeleteAsync(int advertisementId, int userId)
        {
            return await _jobRepo.DeleteAsync(advertisementId, userId);
        }
    }
}