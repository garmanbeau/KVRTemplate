using KVRTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KVRTemplate.Controllers.apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost("register")]
        public IActionResult Register(string username, string password)
        {
            try
            {
                //var response = await _userService.Register(resource, cancellationToken);
                //return Ok(response);

                string x = PasswordHasher.ComputeHash(password, "pepper", 3);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = "hi" });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] JsonElement body)
        {
            //TODO: get context and search for username
            string username = (body.GetProperty("username")).ToString();
            string password = (body.GetProperty("password")).ToString();

            //if (user == null)
            //    throw new Exception("Username or password did not match.");

            string passwdHash = "zTYpKAMCoqYj12ahAoZU25RsI4XlPDizKX2nVphlnNzEXvkHqCZgGPrxDqx0W0ZDkXwJs8KGVE1b8mpU4BsG6Q==";

            string pepper = Environment.GetEnvironmentVariable("PEPPER");
            //TODO: get passwdHash from the db and compare it
            string passwordHash = PasswordHasher.ComputeHash(password, pepper, 3);
            if (passwdHash != passwordHash) //TODO: password hash should be a variable
                throw new Exception("Username or password did not match.");

            return Ok();
            //return whatever needs to do log in.
        }
    }
}
