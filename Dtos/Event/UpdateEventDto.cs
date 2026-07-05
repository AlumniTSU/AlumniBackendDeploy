using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Event
{
    public class UpdateEventDto
{
    public string? TitleGeo { get; set; }
    public string? TitleEng { get; set; }

    public string? DescriptionGeo { get; set; }
    public string? DescriptionEng { get; set; }

    public DateTime? EventDate { get; set; }

    public int? PartnerId { get; set; }
}
}