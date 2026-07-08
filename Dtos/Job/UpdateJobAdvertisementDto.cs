using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Job
{
    public class UpdateJobAdvertisementDto
    {
        public int AdvertisementTypeID { get; set; }

    public bool IsAlumniAd { get; set; }

    public int? PartnerID { get; set; }

    public string? TitleGeo { get; set; }

    public string? TitleEng { get; set; }

    public string? DescriptionGeo { get; set; }

    public string? DescriptionEng { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Salary { get; set; }
    }
}