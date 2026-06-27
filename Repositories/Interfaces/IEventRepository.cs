using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Entities;
using backend.Dtos.Event;


namespace backend.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEventsAsync();
        // Task<Event?> GetByIdAsync(int id);
        // Task<Event> AddAsync(Event entity);
        // Task UpdateAsync(Event entity);
        // Task DeleteAsync(Event entity);
    }
}