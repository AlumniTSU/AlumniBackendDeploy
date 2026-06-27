using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using backend.Dtos.Event;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Mappers;


namespace backend.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AlumniDBContext _context;
        
        public EventRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDto>> GetEventsAsync()
        {
            var events = await _context.Events.FromSqlRaw("EXEC GetEvents").AsNoTracking().ToListAsync();

            return events.Select(s => s.ToEventDto());
        }
    }
}