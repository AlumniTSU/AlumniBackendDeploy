using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Alumni
{
    public class AlumniDto
    {
        public int UserId {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public string Email {get; set;} = null!;
        public string? PhoneNumber {get; set;}
        public string? Bio {get; set;}
        public string? ContactEmail{get; set;}
        public string? ContactPhoneNumber {get; set;}
    }
}