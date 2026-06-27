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
    }
}