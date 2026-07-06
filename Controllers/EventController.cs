using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using backend.Services;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using backend.Dtos.Event;
using System.Security.Claims;

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
        public async Task<IActionResult> GetAll([FromQuery]int languageId = 1)
        {
            var events = await _eventService.GetAllAsync(languageId);

            return Ok(events);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] int languageId = 1)
        {
            var result = await _eventService.GetByIdAsync(languageId, id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateEventWithPhotoDto dto)
        {
            // int createdBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int createdBy = 1;

            

            var created = await _eventService.CreateAsync(dto, createdBy);
            return CreatedAtAction(nameof(GetById), new {id = created.EventId, languageId = 1}, created);
        }


        [HttpPut("{eventId:int}")]
        public async Task<IActionResult> Update(int eventId, [FromBody] UpdateEventDto dto, [FromQuery] int languageId = 1)
        {
            int updatedBy = 1; // later from JWT

            await _eventService.UpdateAsync(eventId, dto, updatedBy);

            var updatedEvent = await _eventService.GetByIdAsync(languageId, eventId);
            

            return Ok(updatedEvent);
        }

        

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            // later this comes from JWT
            int updatedBy = 1;

            await _eventService.DeleteAsync(id, updatedBy);

            return NoContent();
        }
    }
}