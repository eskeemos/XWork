using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonalDataController : ControllerBase
    {
        private readonly ISPersonalData serv;

        public PersonalDataController(ISPersonalData serv)
        {
            this.serv = serv;
        }
        [HttpGet("{id}")]
        public ActionResult<PersonalDataDto> GetById([FromRoute] int id)
        {
            var data = serv.GetPDById(id);
            if (data is null) return NotFound();
            return Ok(data);
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePersonalDataDto personalData)
        {
            serv.UpdatePD(personalData);
            return NoContent();
        }
    }
}
