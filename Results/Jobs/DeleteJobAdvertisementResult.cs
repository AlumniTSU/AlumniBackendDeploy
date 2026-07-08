using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.Jobs
{
    public class DeleteJobAdvertisementResult
    {
        public bool IsDeleted { get; set; }

        public string? Error { get; set; }
    }
}