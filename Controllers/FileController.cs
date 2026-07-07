using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{guid:guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            var sw = Stopwatch.StartNew();

            var file = await _fileService.GetByGuidAsync(guid);
            Console.WriteLine($"DB: {sw.ElapsedMilliseconds} ms");

            sw.Restart();

            var result = File(file!.File1, "image/jpeg");

            Console.WriteLine($"File(): {sw.ElapsedMilliseconds} ms");

            return result;
        }
    }
}