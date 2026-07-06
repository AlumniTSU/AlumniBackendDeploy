using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.News
{
    public class AddNewsResult
    {
         public int? NewsId { get; set; }

        public Guid? NewsGuid { get; set; }

        public bool IsAdded { get; set; }

        public string? Error { get; set; }
    }
}