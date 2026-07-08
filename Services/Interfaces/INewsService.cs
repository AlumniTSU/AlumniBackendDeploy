using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.News;
using backend.Results.News;

namespace backend.Services.Interfaces
{
    public interface INewsService
    {
        Task<AddNewsResult> AddNewsAsync(CreateNewsDto newsDto);
        Task<IEnumerable<NewsDto>> GetAllAsync(int languageId);
    }
}