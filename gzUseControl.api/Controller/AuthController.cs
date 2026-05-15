using gearzone.businesslogic.Interface;
using gearzone.domains.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gzUseControl.Api.Controller
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthActions _auth;

        public AuthController()
        {
            var bl = new gearzone.businesslogic.BusinessLogic();
            _auth = bl.GetAuthActions();
        }

        [HttpGet("status")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok("Session is active");
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] UserAuthDto data)
        {
            var result = _auth.LoginActionFlow(data);

            if (!result.IsSuccess)
                return Unauthorized(result.Message);

            return Ok(new { token = result.Message });
        }

        [HttpGet("admin-only")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Admin access confirmed.");
        }

        [HttpGet("user-area")]
        [Authorize(Roles = "User,Manager,Admin")]
        public IActionResult UserArea()
        {
            return Ok($"Welcome, {User.Identity?.Name}");
        }
    }
}