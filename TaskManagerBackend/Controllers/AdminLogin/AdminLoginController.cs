using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Data.Dto;
using TaskManagerBackend.Services.IServices;
using TaskManagerBackend.Services.Service;

namespace TaskManagerBackend.Controllers.AdminLogin
{
    [Route("api/admin")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {

        public IAdminLogin _service;

        public AdminLoginController(IAdminLogin adminLoginService)
        {
            this._service = adminLoginService;
        }

        [HttpPost("login")]
        public IActionResult 
            login([FromQuery] string Email, [FromQuery] string Password)
        {
            if (_service.Login(Email, Password))
            {
                return Ok("success");
            }
            return NotFound("Invalid Credentials");
        }

        [HttpPost("add")]
        public IActionResult addAdmin([FromBody] NewUserDto admin)
        {

            var res = _service.addAdmin(admin);
            if (res)
            {
                return Ok("Admin added");
            }
            return BadRequest("Invalid Credentials");
        }


    }
}
