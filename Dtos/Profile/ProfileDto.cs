using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.Profile
{
    public class ProfileDto
    {
        public int UserId {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string? LastName {get; set;} 

        public string? Email {get; set;}
        public string? PhoneNumber {get; set;}
        public string? Bio {get; set;}
        public string? ContactEmail {get; set;}
        public string? ContactPhoneNumber {get; set;}
        public string? AdditionalInformation {get; set;}
    }
}