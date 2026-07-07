using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;
using backend.Results;

namespace backend.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllAsync(int languageId);
        Task<EventDetailDto?> GetByIdAsync(int languageId, int eventId);
        Task<EventDetailDto> CreateAsync(CreateEventWithPhotoDto dto, int createdBy);
        Task UpdateAsync(int eventId, UpdateEventDto dto,int updatedBy);
        Task DeleteAsync(int eventId, int updatedBy);
    }
}