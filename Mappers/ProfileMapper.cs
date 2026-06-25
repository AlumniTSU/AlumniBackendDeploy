using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Dtos.Profile;
using backend.Entities;

namespace backend.Mappers
{
    public static class ProfileMapper
    {
        public static ProfileDto ToProfileDto(User user, AlumniProfile? profile, Student? student)
        {
            return new ProfileDto
            {
                UserId = user.UserId,
                FirstName = student!.StudentFirstName,
                LastName = student.StudentLastName,

                Email = user?.Email,
                PhoneNumber = user?.PhoneNumber,

                Bio = profile?.Bio,
                ContactEmail = profile?.ContactEmail,
                ContactPhoneNumber = profile?.ContactPhoneNumber,
                AdditionalInformation = profile?.AdditionalInformation
            };
        }
    }
}