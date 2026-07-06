using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Entities;
using backend.Dtos.Event;
using backend.Results;


namespace backend.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<GetEventsResult>> GetEventsAsync(int languageId);
        Task<GetEventsResult?> GetByIdAsync(int languageId, int eventId);
        Task<AddEventResult> AddAsync(CreateEventDto dto, int createdBy);
        Task<UpdateEventResult> UpdateAsync(int eventId, UpdateEventDto dto, int updatedBy);
        Task<DeleteEventResult> DeleteAsync(int eventId, int updatedBy);
    }
}