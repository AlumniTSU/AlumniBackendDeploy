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
        }
    }
}