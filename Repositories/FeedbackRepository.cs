using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Feedback;
using backend.Entities;
using backend.Repositories.Interfaces;
using backend.Results.Feedback;

namespace backend.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AlumniDBContext _context;
        public FeedbackRepository(AlumniDBContext context)
        {
            _context = context;
        }
        public async Task<AddFeedbackResult> AddAsync(CreateFeedbackDto dto,int userId)
        {
            return await _context.AddFeedbackAsync(dto, userId);
        }
    }
}