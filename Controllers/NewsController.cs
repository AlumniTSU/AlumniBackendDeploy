using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using backend.Dtos.News;
using backend.Results.News;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int languageId)
        {
            var result = await _newsService.GetAllAsync(languageId);
            
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNews([FromForm]CreateNewsDto newsDto)
        {
            var result = await _newsService.AddNewsAsync(newsDto);

            if (!result.IsAdded)
            {
                return BadRequest(result.Error);
            } 

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody]EditNewsDto newsDto)
        {
            var userId = 66;//int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _newsService.EditAsync(id, newsDto, userId);

            if (!result.IsEdited)
                return BadRequest(result.Error);

            return Ok(result);
        }

  }
}