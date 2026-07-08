using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.News
{
    public class EditNewsDto
    {
    // public int? CategoryId { get; set; }

    public string? TitleGeo { get; set; }

    public string? TitleEng { get; set; }

    public string? BodyGeo { get; set; }

    public string? BodyEng { get; set; }

    // public string? SlugGeo { get; set; }

    // public string? SlugEng { get; set; }

    public DateTime? NewsDate { get; set; }
    }
}