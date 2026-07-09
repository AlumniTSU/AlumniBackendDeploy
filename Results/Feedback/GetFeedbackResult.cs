using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.Feedback
{
    public class GetFeedbackResult
    {
        public int FeedbackID { get; set; }

        public int UserID { get; set; }

        public string? UserName { get; set; } = string.Empty;

        public string? Email { get; set; } 

        public string Content { get; set; } = string.Empty;

        public decimal? Rating { get; set; }

        public DateTime? Added_at { get; set; }
    }
}