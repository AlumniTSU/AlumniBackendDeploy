using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.News
{
    public class CreateNewsWithPhotoDto
    {
        public string TitleGeo { get; set; } = string.Empty;
        public string TitleEng { get; set; } = string.Empty;

        public string BodyGeo { get; set; } = string.Empty;
        public string BodyEng { get; set; } = string.Empty;

        public int UserId { get; set; }

        public DateTime NewsDate { get; set; }
        public IFormFile? Photo {get; set;}
    }
}