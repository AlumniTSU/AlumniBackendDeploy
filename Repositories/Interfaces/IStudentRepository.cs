using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IStudentRepository
    {

        Task<Student?> GetByPersonalIdAsync(string personalId);
        Task<Student?> GetByIdAsync(int studentId);
        // Task<Student?> GetByUserIdAsync(int userId);

    }
}