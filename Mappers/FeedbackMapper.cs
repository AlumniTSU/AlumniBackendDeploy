using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Feedback;
using backend.Results.Feedback;

namespace backend.Mappers
{
    public static class FeedbackMapper
    {
        public static FeedbackDto ToFeedbackDto(this GetFeedbackResult result)
        {
            return new FeedbackDto
            {
                FeedbackId = result.FeedbackID,
                UserName = result.UserName,
                Email = result.Email,
                Content = result.Content,
                Rating = result.Rating,
                AddedAt = result.Added_at
            };
    }
    }
}