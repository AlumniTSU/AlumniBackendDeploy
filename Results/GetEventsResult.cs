using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.Results
{
    [Keyless]
    public class GetEventsResult
    {
        public int EventID {get; set;}
        public Guid EventUid { get; set; }
        public string? TitleGeo {get; set;}
        public string? TitleEng {get; set;}
        public string? DescriptionGeo {get; set;}
        public string? DescriptionEng {get; set;}
        public DateTime EventDate {get; set;}
        public int CreatedBy {get; set;}
        public byte[]? File {get; set;}
        public bool? IsMainPic {get; set;}
        public int? FileTypeID {get; set;}
        public string? Extension {get; set;}
        public int? PartnerId {get; set;}
        public DateTime CreatedAt {get; set;}
        public int UpdatedBy {get; set;}
    }
}