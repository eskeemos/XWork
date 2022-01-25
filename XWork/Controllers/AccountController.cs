using Application.Dtos;
using Application.Dtos.AccountDtos;
using Application.Interfaces;
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
        //[HttpGet]
        //public ActionResult<IEnumerable<UpdateAccountDto>> Get()
        //{
        //    return Ok(serv.Get());
        //}
        //[HttpGet("{id}")]
        //public ActionResult<AccountDto> GetById([FromRoute] int id)
        //{
        //    return Ok(serv.GetClientById(id));
        //}
        [HttpPost]
        public ActionResult<AccountInfo> Add(AccountCreate client)
        {
            var data = serv.AddAccount(client);

            return Created($"/api/client/{data.Id}", data);
        }
        //[HttpDelete("{id}")]
        //public IActionResult Remove([FromRoute] int id)
        //{
        //    serv.RemoveClient(id);
        //    return NoContent();
        //}
        //[HttpPut]
        //public IActionResult Update([FromBody] UpdateAccountDto client)
        //{
        //    serv.UpdateClient(client);
        //    return NoContent();
        //}
    }
}
