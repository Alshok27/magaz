using gzUseControl.api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gzUseControl.Api.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // In-memory storage for users (for demonstration purposes)
        private static List<User> _users = new();
        private static int _nextId = 1;

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }
    }
}
