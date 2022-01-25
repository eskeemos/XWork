using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ISClient serv;

        public ClientController(ISClient serv)
        {
            this.serv = serv;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UpdateClientDto>> Get()
        {
            return Ok(serv.Get());
        }
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetById([FromRoute] int id)
        {
            return Ok(serv.GetClientById(id));
        }
        [HttpPost]
        public ActionResult<UpdateClientDto> Add(ClientDto client)
        {
            var data = serv.AddClient(client);
            return Created($"/api/client/{data.Id}",data);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            serv.RemoveClient(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateClientDto client)
        {
            serv.UpdateClient(client);
            return NoContent();
        }
    }
}
