using Application.Dtos.ZusStatementDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZusStatementController : ControllerBase
    {
        private readonly ISZusStatement serv;

        public ZusStatementController(ISZusStatement serv)
        {
            this.serv = serv;
        }
        [HttpGet("{id}")]
        public IActionResult GetZusStatement([FromRoute] int id)
        {
            var x = serv.GetZusStatementById(id);
            return Ok(x);
        }
        [HttpPut]
        public IActionResult UpdateZusStatement([FromBody] UpdateZusStatementDto model)
        {
            serv.UpdateZusStatement(model);
            return Ok();
        }
    }
}
