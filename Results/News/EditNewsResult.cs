using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.News
{
    public class EditNewsResult
    {
        public bool IsEdited { get; set; }

        public string? Error { get; set; }
    }
}