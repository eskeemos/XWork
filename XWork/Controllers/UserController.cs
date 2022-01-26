using Application.Dtos.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISUser serv;

        public UserController(ISUser serv)
        {
            this.serv = serv;
        }
        [HttpPost("register")]
        public ActionResult<int> Register([FromBody] UserRegisterDto dto)
        {
            var id = serv.PostUser(dto);
            return Ok(id);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserLoginDto dto)
        {
            string token = serv.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
