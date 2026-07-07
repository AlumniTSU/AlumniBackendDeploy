using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepo;
        public FileService(IFileRepository fileRepo)
        {
            _fileRepo = fileRepo;
        }

        public async Task<Entities.File?> GetByGuidAsync(Guid guid)
        {
            return await _fileRepo.GetByGuidAsync(guid);
        }
    }
}