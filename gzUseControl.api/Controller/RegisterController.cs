using gearzone.businesslogic.Interface;
using gearzone.domains.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gzUseControl.Api.Controller
{
    [Route("api/reg")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterActions _userReg;

        public RegisterController()
        {
            var bl = new gearzone.businesslogic.BusinessLogic();
            _userReg = bl.GetRegisterActions();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegisterDto uRegData)
        {
            var result = _userReg.RegisterActionFlow(uRegData);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(new { id = result.Id, message = result.Message });
        }
    }
}