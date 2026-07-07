using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Services.Interfaces
{
    public interface IFileService
    {
        Task<Entities.File?> GetByGuidAsync(Guid guid);
    }
}