using Microsoft.AspNetCore.Mvc;
using publishers.Application.Contracts;
using publishers.Application.Service;
using publishers.Infrastructure.Exceptions;
using publishers.Infrastructure.Interfaces;


namespace publishers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyschedController : ControllerBase
    {
        private readonly IRoyschedService royschedService;
        
        public RoyschedController(IRoyschedService royschedService)
        {
            this.royschedService = royschedService;
        }

        [HttpGet ("GetRoyscheds")]
        public IActionResult Get()
        {
            var result = this.royschedService.GetRoyscheds ();
            if (!result.Success == true)
            {
                return BadRequest (result);
            }
            return Ok (result);
        }

        [HttpGet("GetRoyschedById")]
        public IActionResult Get(string id)
        {
            var result = this.royschedService.GetRoyschedById (id);
            if (!result.Success == true)
            {
                return BadRequest(result);
            }
            return Ok (result);
        }

        [HttpPost("SaveRoysched")]
        public IActionResult Post([FromBody] publishers.Application.DTO.Roysched.RoyschedAddDto royschedAddDto)
        {
            var result = this.royschedService.AddRoysched(royschedAddDto);
            if(!result.Success == true) 
            {
                return BadRequest (result);
            }

            return Ok(result.Message);
        }


        [HttpPost("UpdateRoysched")]
        public IActionResult Put([FromBody] Application.DTO.Roysched.RoyschedUpdateDto royschedUpdateDto)
        {
            var result = this.royschedService.UpdateRoyshed(royschedUpdateDto);
            if(!result.Success == true)
            {
                return BadRequest(result);
            }

            return Ok(result.Message);
        }

        [HttpPost("RemoveRoysched")]
        public IActionResult Remove([FromBody] string Id)
        {

            var result = this.royschedService.RemoveRoysched(Id);
            if(!result.Success == true)
            {
                return BadRequest(result);
            }
            return Ok(result.Message);
        }
    }
}
