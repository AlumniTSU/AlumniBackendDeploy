using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Feedback;
using backend.Results.Feedback;

namespace backend.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<AddFeedbackResult> AddAsync(CreateFeedbackDto dto, int userId);
        Task<IEnumerable<GetFeedbackResult>> GetAllAsync();
    }
}