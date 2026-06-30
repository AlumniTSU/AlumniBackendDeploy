using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;
using backend.Mappers;
using backend.Repositories.Interfaces;

namespace backend.Services.Interfaces
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;
        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var events = await _eventRepo.GetEventsAsync();

            return events.Select(s => s.ToEventDto());
        }

        public async Task<EventDto?> GetByIdAsync(int eventId)
        {
            var eventModel = await _eventRepo.GetByIdAsync(eventId);

            if(eventModel == null)
            {
                return null;
            }

            return eventModel.ToEventDto();
        }
    }
}