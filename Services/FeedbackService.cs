using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Mappers;
using backend.Dtos.Feedback;
using backend.Repositories.Interfaces;
using backend.Results.Feedback;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepo;
        public FeedbackService(IFeedbackRepository feedbackRepo)
        {
            _feedbackRepo = feedbackRepo;
        }
        public async Task<AddFeedbackResult> AddAsync(CreateFeedbackDto dto, int userId)
        {
            return await _feedbackRepo.AddAsync(dto, userId);
        }

        public async Task<IEnumerable<FeedbackDto>> GetAllAsync()
        {
            var feedback = await _feedbackRepo.GetAllAsync();

            return feedback.Select(f => f.ToFeedbackDto());
        }

    }
}