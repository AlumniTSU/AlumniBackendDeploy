using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Job
{
    public class JobAdvertisementDto
    {
        public int AdvertisementId { get; set; }
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string? Salary {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
    }
}