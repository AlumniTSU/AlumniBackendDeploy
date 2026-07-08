using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.News
{
    public class GetNewsByLanguageIdResult
    {
        public int NewsId { get; set; }

        public Guid NewsGuid { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;

        public DateTime NewsDate { get; set; }

        public string? FileName { get; set; }

        public byte[]? File { get; set; }

        public int? FileTypeId { get; set; }

        public string? Extension { get; set; }
    }
}