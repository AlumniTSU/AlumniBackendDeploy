using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;
using backend.Entities;
using backend.Results;

namespace backend.Mappers
{
    public static class EventMapper
    {
        public static EventDto ToEventDto(this GetEventsResult eventModel)
        {
            return new EventDto
            {
                EventId = eventModel.EventID,
                Title = eventModel.TitleGeo!,
                Description = eventModel.DescriptionGeo!,
                EventDate = eventModel.EventDate
            };
        }
    }
}