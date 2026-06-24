using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
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
        public async Task<IActionResult> GetAll([FromQuery] QueryObject? search)
        {
            var alumni = await _alumniService.GetAllAsync(search);

            return Ok(alumni);
        }
        

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var alumni = await _alumniService.GetByIdAsync(id);

            if(alumni == null)
            {
                return NotFound();
            }

            return Ok(alumni);
        }
    }
}