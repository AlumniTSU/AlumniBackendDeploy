using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Job
{
    public class CreateJobAdvertisementDto
    {
        public int AdvertisementTypeID { get; set; }

        public bool IsAlumniAd { get; set; }

        public int? PartnerID { get; set; }

        public string TitleGeo { get; set; } = string.Empty;

        public string TitleEng { get; set; } = string.Empty;

        public string DescriptionGeo { get; set; } = string.Empty;

        public string DescriptionEng { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Salary { get; set; }
    }
}