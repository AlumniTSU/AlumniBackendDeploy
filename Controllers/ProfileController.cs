using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using backend.Services.Interfaces;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        [Authorize]
[HttpGet("me")]
public async Task<IActionResult> Me()
{
    var userIdClaim =
        User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if(userIdClaim == null)
        return Unauthorized();

    int userId = int.Parse(userIdClaim);

    var user =
        await _profileService.GetProfileAsync(userId);

    if(user == null)
        return NotFound();

    return Ok(new
    {
        user.UserId,
        user.FirstName,
        user.LastName,
        user.Email
    });
}


        [Authorize]
        [HttpGet("claims")]
        public IActionResult ClaimsTest()
        {
            return Ok(
                User.Claims.Select(c => new
                {
                    c.Type,
                    c.Value
                })
            );
        }

        [HttpGet("headers")]
        public IActionResult Headers()
        {
            return Ok(
                Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())
            );
        }
    }
}