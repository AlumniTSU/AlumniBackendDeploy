using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using backend.Dtos.Event;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Mappers;
using backend.Results;
using backend.Results.Event;


namespace backend.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AlumniDBContext _context;
        
        public EventRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetEventsResult>> GetEventsAsync(int languageId)
        {
            var sw = Stopwatch.StartNew();

            var eventVar = await _context.GetEvents(languageId).ToListAsync();
            
            sw.Stop();

            Console.WriteLine($"Repository: {sw.ElapsedMilliseconds} ms");
            
            return eventVar;
            
        }

        public async Task<GetEventByIdResult?> GetByIdAsync(int languageId, int eventId)
        {
            // return await _context.Events.FirstOrDefaultAsync(s => s.EventId == eventId);
            return await _context.GetEventByLanguageIdAndEventIdAsync(languageId, eventId);
        }

        public async Task<AddEventResult> AddAsync(CreateEventDto dto, int createdBy)
        {
            return await _context.AddEventAsync(dto, createdBy);
        }


        public async Task<UpdateEventResult> UpdateAsync(int eventId, UpdateEventDto dto, int updatedBy)
        {
            return await _context.UpdateEventAsync(eventId, dto, updatedBy);
        }
        
        

        public async Task<DeleteEventResult> DeleteAsync(int eventId, int updatedBy)
        {
            return await _context.DeleteEventAsync(eventId, updatedBy);
        }
    }
}