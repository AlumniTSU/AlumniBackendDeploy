using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public class QueryObject
    {
        public string? FirstName{get; set;} = null;
        public string? LastName {get; set;} = null;
        public int PageNumber {get; set;} = 1;
        public int PageSize {get; set;} = 20;
        public string? SortBy {get; set;} 
        public bool IsDescending {get; set;}
    }
}