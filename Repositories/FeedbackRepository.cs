using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Feedback;
using backend.Entities;
using backend.Results.Feedback;

namespace backend.Repositories
{
    public class FeedBackRepository
    {
        private readonly AlumniDBContext _context;
        public FeedBackRepository(AlumniDBContext context)
        {
            _context = context;
        }
        public async Task<AddFeedbackResult> AddAsync(CreateFeedbackDto dto,int userId)
        {
            return await _context.AddFeedbackAsync(dto, userId);
        }
    }
}