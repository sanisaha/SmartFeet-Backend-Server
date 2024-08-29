using Ecommerce.Domain.src.UserAggregate;
using Ecommerce.Domain.src.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.src.UserService;
using Ecommerce.Domain.src.Auth;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : AppController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserManagement _userManagement;

        public UserController(IUserManagement userManagement) : base(userManagement)
        {
            _userManagement = userManagement;
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<UserReadDto>> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        [Authorize]
        public override async Task<ActionResult<UserReadDto>> CreateAsync(UserCreateDto entity)
        {
            return await base.CreateAsync(entity);
        }

        [Authorize]
        public override async Task<ActionResult<UserReadDto>> UpdateAsync(Guid id, UserUpdateDto entity)
        {
            return await base.UpdateAsync(id, entity);
        }

        [Authorize]
        public override async Task<ActionResult> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }

        // GET: api/v1/users/{userEmail}
        [HttpGet("{userEmail}")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize]
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
