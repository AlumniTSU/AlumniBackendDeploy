using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Feedback
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }

        public string? UserName { get; set; } 

        public string? Email { get; set; } 

        public string Content { get; set; } = string.Empty;

        public decimal? Rating { get; set; }

        public DateTime? AddedAt { get; set; }
    }
}