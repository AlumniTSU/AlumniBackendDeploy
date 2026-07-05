using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using backend.Dtos.Event;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Mappers;
using backend.Results;


namespace backend.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AlumniDBContext _context;
        
        public EventRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetEventsResult>> GetEventsAsync()
        {
            return await _context.GetEvents().ToListAsync();
            // return events.Select(s => s.ToEventDto());
        }

        public async Task<GetEventsResult?> GetByIdAsync(int languageId, int eventId)
        {
            // return await _context.Events.FirstOrDefaultAsync(s => s.EventId == eventId);
            return await _context.GetEventByLanguageIdAndEventIdAsync(languageId, eventId);
        }

        public async Task<AddEventResult> AddAsync(CreateEventDto dto, int createdBy)
        {
            return await _context.AddEventAsync(dto, createdBy);
        }

        
    }
}