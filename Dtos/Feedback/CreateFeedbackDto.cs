using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Feedback
{
    public class CreateFeedbackDto
    {
        public string Content { get; set; } = string.Empty;

        public decimal? Rating { get; set; }
    }
}