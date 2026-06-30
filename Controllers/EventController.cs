using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using backend.Services;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();

            return Ok(events);
        }


        [HttpGet]
        [Route("{eventId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int eventId)
        {
            var result = await _eventService.GetByIdAsync(eventId);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}