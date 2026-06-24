using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using backend.Dtos.Student;
using backend.Entities;

namespace backend.Mappers
{
    public static  class StudentMapper
    {
        public static AlumniDto ToAlumniDto(this Student studentModel)
        {
            return new AlumniDto
            {
                StudentId = (int)studentModel.StudentId,
                StudentFirstName = studentModel.StudentFirstName,
                StudentLastName = studentModel.StudentLastName,
                Email = studentModel.Email,
                PhoneNumber = studentModel.PhoneNumber
            };
        }

        public static AlumniDetailsDto ToAlumniDetailsDto(this Student student)
        {
            return new AlumniDetailsDto
            {
                StudentId = (int)student.StudentId,
                FirstName = student.StudentFirstName,
                LastName = student.StudentLastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Bio = null,
                ContactEmail = student.Email,
                ContactPhoneNumber = student.PhoneNumber
            };
        }
        
    }
}