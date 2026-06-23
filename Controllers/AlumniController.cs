using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/alumni")]
    public class AlumniController : ControllerBase
    {
        private readonly IAlumniService _alumniService;

        public AlumniController (IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alumni = await _alumniService.GetAllAsync();

            return Ok(alumni);
        }
        
    }
}