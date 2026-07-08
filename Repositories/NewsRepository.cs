using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.News;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Results.News;

namespace backend.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly AlumniDBContext _context;
        public NewsRepository(AlumniDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetNewsByLanguageIdResult>> GetAllAsync(int languageId)
        {
            return await _context.GetNewsByLanguageIdAsync(languageId);
        }

        
        public async Task<AddNewsResult> AddNewsAsync(CreateNewsDto newsDto)
        {
            return await _context.AddNewsAsync(newsDto);
        }

        public async Task<EditNewsResult> EditAsync(int id, EditNewsDto dto, int userId)
        {
            return await _context.EditNewsAsync(id, dto, userId);
        }
    }
}