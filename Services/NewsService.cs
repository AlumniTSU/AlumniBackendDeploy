using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.News;
using backend.Repositories.Interfaces;
using backend.Results.News;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepo;
        public NewsService(INewsRepository newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public async Task<AddNewsResult> AddNewsAsync(CreateNewsDto newsDto)
        {
            return await _newsRepo.AddNewsAsync(newsDto);
            // var createDto = new CreateNewsDto
            // {
            //     TitleGeo = dto.TitleGeo,
            //     TitleEng = dto.TitleEng,
            //     BodyGeo = dto.BodyGeo,
            //     BodyEng = dto.BodyEng,
            //     NewsDate = dto.NewsDate
            // };

            // var newsResult = await _newsRepo.AddNewsAsync(createDto);
            // if(!newsResult.IsAdded || newsResult.NewsGuid is null)
            // {
            //     throw new InvalidOperationException(newsResult.Error ?? "Failed to add news");
            // }

            // if(dto.Photo is not null && dto.Photo.Length > 0)
            // {
            //     byte[] bytes;
            //     using (var ms = new MemoryStream())
            //     {
                    
            //     }
            // }
        }
    }
}