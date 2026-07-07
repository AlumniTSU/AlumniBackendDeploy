using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Job;
using backend.Results.Jobs;

namespace backend.Mappers
{
    public static class JobMapper
    {
        public static JobAdvertisementDto ToJobDto(this GetJobAdvertisementsResult jobModel)
        {
            return new JobAdvertisementDto
            {
                AdvertisementId = jobModel.AdvertisementID,
                Title = jobModel.Title,
                Description = jobModel.Description,
                Salary = jobModel.Salary,
                StartDate = jobModel.StartDate,
                EndDate = jobModel.EndDate
                
            };
        }
    }
}