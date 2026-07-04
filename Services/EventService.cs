using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Event;
using backend.Dtos.File;
using backend.Mappers;
using backend.Repositories.Interfaces;

namespace backend.Services.Interfaces
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;
        private readonly IFileRepository _fileRepo;
        public EventService(IEventRepository eventRepo, IFileRepository fileRepo)
        {
            _eventRepo = eventRepo;
            _fileRepo = fileRepo;
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

        public async Task<EventDto> CreateAsync(CreateEventWithPhotoDto dto, int createdBy)
        {
            var createDto = new CreateEventDto
            {
                TitleGeo = dto.TitleGeo,
                TitleEng = dto.TitleEng,
                DescriptionGeo = dto.DescriptionGeo,
                DescriptionEng = dto.DescriptionEng,
                EventDate = dto.EventDate,
                PartnerId = dto.PartnerId
            };

            var eventResult = await _eventRepo.AddAsync(createDto, createdBy);
            if(!eventResult.IsAdded || eventResult.EventUid is null)
                throw new InvalidOperationException(eventResult.Error ?? "Failed to add event");
            
            if(dto.Photo is not null && dto.Photo.Length > 0)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    await dto.Photo.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }

                var fileDto = new AddFileDto
                {
                    ContentGuid = eventResult.EventUid.Value,
                    EntityTypeId = 1,
                    FileName = $"{Guid.NewGuid()}_{dto.Photo.FileName}",
                    File = bytes,
                    FileTypeId = 1,
                    UserId = createdBy,
                    IsMainPic = true,
                };

                var fileResult = await _fileRepo.AddFileAsync(fileDto);
                if(!fileResult.IsAdded)
                    throw new InvalidOperationException(fileResult.Error ?? "Failed to add file");
            }

            return new EventDto
            {
                EventId = eventResult.EventId!.Value,
                Title = dto.TitleGeo,
                Description = dto.DescriptionGeo,
                EventDate = dto.EventDate,
            };
            
            
            
            
            
            // var result = await _eventRepo.AddAsync(dto, createdBy);

            // if(!result.IsAdded)
            //     throw new InvalidOperationException(result.Error ?? "Failed to add event.");
            
            // return new EventDto
            // {
            //     EventId = result.EventId!.Value,
            //     Title = dto.TitleGeo,
            //     Description = dto.DescriptionGeo,
            //     EventDate = dto.EventDate,
            // };
        }

        
    }
}