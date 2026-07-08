using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Results.Jobs
{
    public class GetJobAdvertisementsResult
{
    public int AdvertisementID { get; set; }
    public Guid AdvertisementGUID { get; set; }
    public int AdvertisementTypeID { get; set; }

    public string AdvertisementType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Salary { get; set; }

    public int AddedByUserID { get; set; } 
    public string? AddedByUser { get; set; } 

    public int? PartnerID { get; set; }
    public string? PartnerName { get; set; }
}
}