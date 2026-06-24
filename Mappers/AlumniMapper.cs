using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Dtos.Student;
using backend.Entities;

namespace backend.Mappers
{
    public static class AlumniMapper
    {
        public static AlumniDetailsDto ToAlumniDetailsDto(Student student, User? user, AlumniProfile? profile)
        {
            return new AlumniDetailsDto
            {
                StudentId = (int)student.StudentId,
                FirstName = student.StudentFirstName,
                LastName = student.StudentLastName,

                Email = user?.Email ?? student.Email ?? string.Empty,
                PhoneNumber = user?.PhoneNumber,

                Bio = profile?.Bio,

                ContactEmail = profile?.ContactEmail,
                ContactPhoneNumber = profile?.ContactPhoneNumber
            };
        }
    }
}