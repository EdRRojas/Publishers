using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using publishers.Application.Dtos.Titles;
using publishers.Api.Models;
using publishers.Application.Contract;
using publishers.Domain.Entities;
using publishers.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publishers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitlesServices titlesServices;

        public TitlesController(ITitlesServices titlesServices)
        {
            this.titlesServices = titlesServices;
        }
        // GET: api/<TitlesController>
        [HttpGet("GetTitles")]
        public IActionResult Get()
        {
            var Titles = this.titlesServices.GetAll();
            if (!Titles.Success)
            {
                return BadRequest(Titles);
            }
            return Ok(Titles);
        }

        // GET api/<TitlesController>/5
        [HttpGet("GetTitle")]
        public IActionResult Get(string id)
        {
            var Title = this.titlesServices.Get(id);

            if (!Title.Success)
            {
                return BadRequest(Title);
            }

            return Ok(Title);
        }

        // POST api/<TitlesController>
        [HttpPost("CreateTitle")]
        public IActionResult Post([FromBody] TitlesDtoAdd titlesDtoAdd)
        {
            var Title = this.titlesServices.Create(titlesDtoAdd);

            if (!Title.Success)
            {
                return BadRequest(Title);
            }

            return Ok(Title);
        }

        // PUT api/<TitlesController>/5
        [HttpPut("TitlesUpdate")]
        public IActionResult Put([FromBody] TitlesDtoUpdate titlesUpdateDto)
        {
            var Title = this.titlesServices.Update(titlesUpdateDto);

            if (!Title.Success)
            {
                return BadRequest(Title);
            }

            return Ok(Title);
        }

        // DELETE api/<TitlesController>/5
        [HttpDelete("TitleRemove")]
        public IActionResult Delete([FromBody] TitlesDtoDelete titlesDeleteDto)
        {
            var Title = this.titlesServices.Remove(titlesDeleteDto);

            if (!Title.Success)
            {
                return BadRequest(Title);
            }

            return Ok(Title);
        }

        [HttpGet("GetTitleByName")]
        public IActionResult GetTitlesByName(string name)
        {
            var titles = this.titlesServices.GetTitleByName(name);

            if (!titles.Success)
            {
                return BadRequest(titles);
            }
            return Ok(titles);
        }

        [HttpGet("GetTitlesByType")]
        public IActionResult GetTitlesByType(string type)
        {
            var titles = this.titlesServices.GetTitlesByType(type);

            if (!titles.Success)
            {
                return BadRequest(titles);
            }

            return Ok(titles);
        }

        [HttpGet("GetTitlesByPub")]
        public IActionResult GetTitlesByPub(string pub_Id)
        {
            var titles = this.titlesServices.GetTitlesByPub(pub_Id);

            if (!titles.Success)
            {
                return BadRequest(titles);
            }

            return Ok(titles);
        }

        [HttpGet("GetTitlesByUnderPrice")]
        public IActionResult GetTitlesByUnderPrice(decimal price)
        {
            var titles = this.titlesServices.GetTitlesByUnderPrice(price);

            if (!titles.Success)
            {
                return BadRequest(titles);
            }

            return Ok(titles);
        }

        [HttpGet("GetTitlesByOnPrice")]
        public IActionResult GetTitlesByOnPrice(decimal price)
        {
            var titles = this.titlesServices.GetTitlesByOnPrice(price);

            if (!titles.Success)
            {
                return BadRequest(titles);
            }

            return Ok(titles);
        }

        [HttpGet("GetTitleSalesByID")]
        public IActionResult GetTitleSalesByID(string id)
        {
            var titles = this.titlesServices.GetTitleSalesByID(id);

            if (!titles.Success)
            {
                return BadRequest(titles);
            }

            return Ok(titles);
        }        
    }
}
