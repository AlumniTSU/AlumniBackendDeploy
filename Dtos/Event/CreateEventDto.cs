using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Event
{
    public class CreateEventDto
    {
        public string TitleGeo {get ;set;} = string.Empty;
        public string TitleEng {get; set;} = string.Empty;
        public string DescriptionGeo {get; set;} = string.Empty;
        public string DescriptionEng {get; set;} = string.Empty;
        public DateTime EventDate {get; set;} 
        public int? PartnerId {get; set;}
    }
}