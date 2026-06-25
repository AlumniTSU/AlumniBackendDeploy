using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using backend.Services.Interfaces;
using backend.Dtos.Profile;

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
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim);

            var profile = await _profileService.GetProfileAsync(userId);

            if(profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
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

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = Convert.ToInt32(userIdClaim);

            var success = await _profileService.UpdateProfileAsync(userId, dto);

            if (success == null)
            {
                return NotFound();
            }

            return Ok(success);
        }

        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(UpdatePasswordDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = Convert.ToInt32(userIdClaim);

            var success = await _profileService.UpdatePasswordAsync(userId, dto);

            if (!success)
            {
                return BadRequest("Invalid old password.");
            }

            return Ok(new
            {
                Message = "Password changed successfully."
            });
        }
    }
}