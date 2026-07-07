using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.File;
using backend.Results;

namespace backend.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task<Entities.File?> GetByGuidAsync(Guid guid);
        Task<AddFileResult> AddFileAsync(AddFileDto dto);
    }
}