using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results
{
    public class DeleteEventResult
    {
        public bool IsDeleted {get; set;}
        public string? Error {get; set;}
    }
}