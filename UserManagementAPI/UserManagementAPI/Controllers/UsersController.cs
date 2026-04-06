using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Data;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(UserStore.Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = UserStore.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email))
                return BadRequest("Name and Email are required");

            user.Id = UserStore.Users.Count + 1;

            UserStore.Users.Add(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = UserStore.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserStore.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            UserStore.Users.Remove(user);

            return Ok("User deleted");
        }
    }
}