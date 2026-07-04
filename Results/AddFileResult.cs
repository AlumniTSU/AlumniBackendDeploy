using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results
{
    public class AddFileResult
    {
        public int? FileId {get; set;}
        public bool IsAdded {get; set;}
        public string? Error {get; set;}
    }
}