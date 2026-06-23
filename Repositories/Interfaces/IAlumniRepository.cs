using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Alumni;

namespace backend.Repositories.Interfaces
{
    public interface IAlumniRepository
    {
        Task<List<AlumniDto>> GetAllAsync();
    }
}