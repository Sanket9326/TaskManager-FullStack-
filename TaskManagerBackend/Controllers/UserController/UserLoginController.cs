using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Data.Dto;
using TaskManagerBackend.Data.Entity;
using TaskManagerBackend.Services.IServices;
using TaskManagerBackend.Services.Service;

namespace TaskManagerBackend.Controllers.UserController
{
    [Route("api/user")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {

        public IUserLoginService service;

        public UserLoginController(IUserLoginService service)
        {
            this.service = service;
        }

        [HttpPost("login")]
        public ActionResult login([FromQuery] string Email, [FromQuery] string Password)
        {
            var res = service.login(Email, Password);
            if (res)
            {
                return Ok("success");
            }
            return Unauthorized("Invalid user");
        }

        [HttpPut("add")]
        public ActionResult addUser([FromBody] NewUserDto newUserDto)
        {
            var res = service.addUser(newUserDto);
            if (res.Equals(true))
            {
                return Created();
            }
            return BadRequest();
        }


        [HttpPost("recovery")]
        public ActionResult passwordRecovery([FromQuery] string Username)
        {
            var res = service.passwordRecovery(Username);
            
            if (res.Equals(true))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public ActionResult deleteUser([FromQuery] int id)
        {
            var res = service.deleteUser(id);
            if (res.Equals(true))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
