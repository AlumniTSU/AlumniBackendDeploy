using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.File;
using backend.Dtos.News;
using backend.Mappers;
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

        public async Task<IEnumerable<NewsDto>> GetAllAsync(int languageId)
        {
            var news = await _newsRepo.GetAllAsync(languageId);

            return news.Select(n => n.ToNewsDto());
        }

        public async Task<AddNewsResult> AddNewsAsync(CreateNewsDto dto)
        {
            return await _newsRepo.AddNewsAsync(dto);
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
            //         await dto.Photo.CopyToAsync(ms);
            //         bytes = ms.ToArray();
            //     }

            //     var fileDto = new AddFileDto
            //     {
            //         ContentGuid = newsResult.NewsGuid.Value,
            //         EntityTypeId = 1,
            //         FileName = $"{Guid.NewGuid()}_{dto.Photo.FileName}",
            //         File = bytes,
            //         FileTypeId = 1,
            //         IsMainPic = true,
            //     };

                
                
                
            //}
        }

        public async Task<EditNewsResult> EditAsync(int id, EditNewsDto newsDto, int userId)
        {
            return await _newsRepo.EditAsync(id, newsDto, userId);
        }
    }
}