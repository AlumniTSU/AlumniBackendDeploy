using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.Jobs
{
    public class AddJobAdvertisementResult
    {
        public int? AdvertisementID { get; set; }

        public Guid? AdvertisementGUID { get; set; }

        public bool IsAdded { get; set; }

        public string? Error { get; set; }
    }
}