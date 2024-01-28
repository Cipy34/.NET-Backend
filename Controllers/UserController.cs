using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using RecipeBlog.Services.UserService;
//using RecipeBlog.Services.PersonService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBlog.Exceptions;

namespace RecipeBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
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
                Password = user.Password,
                PersonId = user.PersonId
            };

            await _userService.AddUser(nuser, person);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> DisplayUsers()
        {
            return await _userService.DisplayUsers();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> UserById(int userId)
        {
            var users = await _userService.UserById(userId);
            return Ok(users);  
        }
    }
}
