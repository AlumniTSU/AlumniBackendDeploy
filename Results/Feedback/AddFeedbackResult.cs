using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.Feedback
{
    public class AddFeedbackResult
    {
        public int? FeedbackID { get; set; }

        public bool IsAdded { get; set; }

        public string? Error { get; set; }
    }
}