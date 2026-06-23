using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Alumni
{
    public class AlumniDto
    {
        public long StudentId {get; set;}
        public string StudentFirstname {get; set;} = null!;
        public string? StudentLastName {get; set;}
        public string? Email {get; set;}
        public string? PhoneNumber {get; set;}
    }
}