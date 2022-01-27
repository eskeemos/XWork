using Application.Dtos;
using Application.Dtos.AccountDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISAccount serv;

        public AccountController(ISAccount serv)
        {
            this.serv = serv;
        }
        [HttpPost("register")]
        public ActionResult<int> Register([FromBody] AccountRegister dto)
        {
            var id = serv.PostUser(dto);
            return Ok(id);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] AccountLogin dto)
        {
            var data = serv.LogToAccount(dto);
            return Ok(data);
        } 
        [HttpGet]
        public ActionResult<IEnumerable<AccountInfo>> Get()
        {
            return Ok(serv.GetAccounts());
        }
        [HttpGet("{id}")]
        public ActionResult<AccountInfo> GetById([FromRoute] int id)
        {
            var account = serv.GetAccountById(id);
            if (account is null) return null;
            return Ok(account);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            var account = serv.GetAccountById(id);
            if(account is null) return NotFound();

            serv.RemoveAccount(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update([FromBody] AccountUpdate client)
        {
            serv.UpdateAccount(client);
            return NoContent();
        }

    }
}
