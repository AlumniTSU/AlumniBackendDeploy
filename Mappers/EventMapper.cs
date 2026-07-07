using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;
using backend.Entities;
using backend.Results;
using backend.Results.Event;

namespace backend.Mappers
{
    public static class EventMapper
    {
        public static EventDto ToEventDto(this GetEventsResult eventModel)
        {
            return new EventDto
            {
                EventId = eventModel.EventId,
                Title = eventModel.Title!,
                Description = eventModel.Description!,
                EventDate = eventModel.EventDate,
                // File = eventModel.File,
                // Extension = eventModel.Extension
            };
        }

        public static EventDetailDto ToEventDetailDto(this GetEventByIdResult eventModel)
        {
            return new EventDetailDto
            {
                EventId = eventModel.EventId,
                Title = eventModel.Title!,
                Description = eventModel.Description!,
                EventDate = eventModel.EventDate,
                ImageUrl = $"api/files/{eventModel.EventUid}"
                // File = eventModel.File,
                // Extension = eventModel.Extension
            };
        }

        public static EventDto ToEventDto(this Event eventModel)
        {
            return new EventDto
            {
                EventId = eventModel.EventId,
                Title = eventModel.TitleGeo!,
                Description = eventModel.DescriptionGeo!,
                EventDate = eventModel.EventDate
            };
        }
    }
}