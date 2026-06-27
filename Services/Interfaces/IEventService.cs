using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;

namespace backend.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllAsync();
        // Task<EventDto?> GetByIdAsync(int id);
        // Task<EventDto> CreateAsync(CreateEventDto dto);
        // Task UpdateAsync(int id, UpdateEventDto dto);
        // Task DeleteAsync(int id);
    }
}