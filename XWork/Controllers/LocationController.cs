using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ISLocation serv;

        public LocationController(ISLocation serv)
        {
            this.serv = serv;
        }

        [HttpGet("{id}")]
        public ActionResult<LocationDto> GetById([FromRoute] int id)
        {
            var location = serv.GetLocationById(id);
            if (location is null) return NotFound();
            return Ok(location);
        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateLocationDto location)
        {
            serv.Update(location);
            return NoContent();
        }
    }
}
