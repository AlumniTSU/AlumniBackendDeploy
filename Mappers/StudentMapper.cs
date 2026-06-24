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
                StudentId = studentModel.StudentId,
                StudentFirstName = studentModel.StudentFirstName,
                StudentLastName = studentModel.StudentFirstName,
                Email = studentModel.Email,
                PhoneNumber = studentModel.PhoneNumber
            };
        }
    }
}