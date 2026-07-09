using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Results.Feedback;
using backend.Dtos.Feedback;

namespace backend.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<AddFeedbackResult> AddAsync(CreateFeedbackDto dto, int userId);
        Task<IEnumerable<FeedbackDto>> GetAllAsync();
    }
}