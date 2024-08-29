using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.src.UserService;
using Ecommerce.Domain.src.Auth;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserManagement _userManagement;

        public UserController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        // GET: api/v1/users/{userEmail}
        [HttpGet("{userEmail}")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            var user = await _userManagement.GetUserByEmail(userEmail);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // GET: api/v1/users/{usserCredentials}
        [HttpGet("{userCredentials}")]
        public async Task<IActionResult> GetUserByCredentials(UserCredentials userCredentials)
        {
            var user = await _userManagement.GetByCredentialsAsync(userCredentials);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // put: api/v1/users/{userId}/{newPassword}
        [HttpPut("{userId}/{newPassword}")]
        public async Task<IActionResult> UpdatePassword(Guid userId, string newPassword)
        {
            var result = await _userManagement.UpdatePasswordAsync(userId, newPassword);
            if (!result)
            {
                return NotFound("User not found.");
            }
            return NoContent();
        }

    }
}
