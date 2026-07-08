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
        public async Task<IActionResult> GetAll([FromQuery]int advertisementTypeId, [FromQuery] int languageId = 1)
        {
            var jobs = await _jobService.GetJobAdvertisementsAsync(languageId, advertisementTypeId);

            return Ok(jobs);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody]CreateJobAdvertisementDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            Console.WriteLine($"UserId: {userId}");
            //var userId = 61;
            var result = await _jobService.AddAsync(dto, userId);

            if (!result.IsAdded)
                return BadRequest(result.Error);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery]int languageId)
        {
            var job = await _jobService.GetByIdAsync(languageId, id);

            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJobAdvertisementDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _jobService.UpdateAsync(id, dto, userId);

            if (!result.IsEdited)
                return BadRequest(result.Error);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _jobService.DeleteAsync(id, userId);

            if (!result.IsDeleted)
                return BadRequest(result.Error);

            return Ok(result);
        }
    }

}