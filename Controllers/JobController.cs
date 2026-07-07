using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using backend.Services.Interfaces;
using backend.Dtos.Job;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CreateJobAdvertisementDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _jobService.AddAsync(dto, userId);

            if (!result.IsAdded)
                return BadRequest(result.Error);

            return Ok(result);
        }
    }

}