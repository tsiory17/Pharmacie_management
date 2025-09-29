using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.Replication;
using Pharmacie_management.Dtos;
using Pharmacie_management.Models;
using Pharmacie_management.Repositories;

namespace Pharmacie_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("register")]

        public IActionResult Register(RegisterDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "the credentials are invalid" });
            }

            //Add new user 
            var newUser = new User
            {
                Name = userDto.Name.ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };

            _userRepository.AddUser(newUser);
            return Ok(new { message = "registered" });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Incorrect username or Password" });
            }
            //check in the db if username exist if it exist verify if password matches 
            // if (await _userRepository.GetUserByName(loginDto.Name) == null)
            // {
            //     return BadRequest("The user do not exist");
            // }
            if (await _userRepository.IsLoginValid(loginDto.Name, loginDto.Password))
            {
                return Ok(new { message = "logged in" });
            }
            return BadRequest(new { message = "Incorrect Username or Password" });

        }
    }
}