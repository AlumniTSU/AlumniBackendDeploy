using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int languageId, int advertisementTypeId)
        {
            var jobs = await _jobService.GetJobAdvertisementsAsync(languageId, advertisementTypeId);

            return Ok(jobs);
        }
    }
}