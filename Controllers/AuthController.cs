using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using RecipeBlog.Services.UserService;

namespace RecipeBlog.Controllers
{
    [Route("api/Registration")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            // Create Person
            var person = new Person
            {
                //PersonId = user.PersonId,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            // Create User
            var nuser = new User
            {
                //UserId = user.UserId,
                UserName = user.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                PersonId = user.PersonId
            };

            await _userService.AddUser(nuser, person);

            return Ok(nuser);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {

            var users = await _userService.UserLogin(username, password);
            return Ok(users);
        }
    }
}
