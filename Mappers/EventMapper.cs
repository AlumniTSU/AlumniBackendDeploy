using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;
using backend.Entities;

namespace backend.Mappers
{
    public static class EventMapper
    {
        public static EventDto ToEventDto(this Event eventModel)
        {
            return new EventDto
            {
                EventId = eventModel.EventId,
                Title = eventModel.TitleGeo,
                Description = eventModel.DescriptionGeo!,
                EventDate = eventModel.EventDate,
            };
        }
    }
}