using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Student
{
    public class AlumniDto
    {
        public int StudentId {get; set;}
        public string StudentFirstName {get; set;} = null!;
        public string? StudentLastName {get; set;}
        public string? Email {get; set;}
        public string? PhoneNumber {get; set;}
    }
}