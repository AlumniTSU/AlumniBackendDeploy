using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.File
{
    public class AddFileDto
    {
        public Guid ContentGuid {get; set;}
        public int EntityTypeId {get; set;}
        public string FileName {get; set;} = string.Empty;
        public byte[] File {get; set;} = Array.Empty<byte>();
        public int FileTypeId {get; set;}
        public int UserId {get; set;}
        public bool IsMainPic {get; set;}
    }
}