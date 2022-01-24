using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost]
        public IActionResult Add([FromBody] PersonalDataDto personalData)
        {
            var data = serv.Add(personalData);
            return Created($"/api/PersonalData/{data.Id}", data);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            serv.RemovePD(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePersonalDataDto personalData)
        {
            serv.UpdatePD(personalData);
            return NoContent();
        }
    }
}
