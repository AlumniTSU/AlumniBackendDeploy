using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.News;
using backend.Results.News;

namespace backend.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<AddNewsResult> AddNewsAsync(CreateNewsDto newsDto);
        Task<IEnumerable<GetNewsByLanguageIdResult>> GetAllAsync(int languageId);
        Task<EditNewsResult> EditAsync(int id, EditNewsDto newsDto, int userId);
        Task<DeleteNewsResult> DeleteAsync(int id, int userId);
    }
    
}