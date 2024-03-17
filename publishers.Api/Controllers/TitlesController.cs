using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using publishers.Api.Dtos.Titles;
using publishers.Api.Models;
using publishers.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publishers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitlesRepository titlesRepository;

        public TitlesController(ITitlesRepository titlesRepository)
        {
            this.titlesRepository = titlesRepository;
        }
        // GET: api/<TitlesController>
        [HttpGet("GetTitles")]
        public IActionResult Get()
        {
            var Titles = this.titlesRepository.GetEntities();
            return Ok(Titles);
        }

        // GET api/<TitlesController>/5
        [HttpGet("GetTitle")]
        public IActionResult Get(string id)
        {
            var Title = this.titlesRepository.GetEntity(id);
            return Ok(Title);
        }

        // POST api/<TitlesController>
        [HttpPost("CreateTitle")]
        public void Post([FromBody] TitlesAddDto titlesAddDto)
        {
            this.titlesRepository.Create(new publishers.Domain.Entities.Titles()
            {
                title_id = titlesAddDto.title_id,
                title = titlesAddDto.title,
                type = titlesAddDto.type,
                pub_id = titlesAddDto.pub_id,
                price = titlesAddDto.price,
                advance = titlesAddDto.advance,
                royalty = titlesAddDto.royalty,
                ytd_sales = titlesAddDto.ytd_sales,
                notes = titlesAddDto.notes,
                pubdate = titlesAddDto.pubdate,
                creationUser = titlesAddDto.UserId,
                creationDate = titlesAddDto.modifyDate
            });
        }

        // PUT api/<TitlesController>/5
        [HttpPut("TitlesUpdate")]
        public void Put([FromBody] TitlesUpdateDto titlesUpdateDto)
        {
            this.titlesRepository.Update(new Domain.Entities.Titles()
            {
                title_id = titlesUpdateDto.title_id,
                title = titlesUpdateDto.title,
                type = titlesUpdateDto.type,
                price = titlesUpdateDto.price,
                advance = titlesUpdateDto.advance,
                royalty = titlesUpdateDto.royalty,
                ytd_sales = titlesUpdateDto.ytd_sales,
                notes = titlesUpdateDto.notes,
                userMod = titlesUpdateDto.UserId,
                modifyDate = titlesUpdateDto.modifyDate
            });

        }

        // DELETE api/<TitlesController>/5
        [HttpDelete("TitleRemove")]
        public void Delete([FromBody] TitlesDeleteDto titlesDeleteDto)
        {
            this.titlesRepository.Remove(new Domain.Entities.Titles()
            {
                title_id= titlesDeleteDto.title_id,
                deleted = true,
                userDelete = titlesDeleteDto.UserId,
                deleteTime = titlesDeleteDto.modifyDate
            });
        }

        [HttpGet("GetTitleByName")]
        public IActionResult GetTitlesByName(string name)
        {
            var titles = this.titlesRepository.GetTitleByName(name);
            return Ok(titles);
        }

        [HttpGet("GetTitlesByType")]
        public IActionResult GetTitlesByType(string type)
        {
            var titles = this.titlesRepository.GetTitlesByType(type);
            return Ok(titles);
        }

        [HttpGet("GetTitlesByPub")]
        public IActionResult GetTitlesByPub(string pub_Id)
        {
            var titles = this.titlesRepository.GetTitlesByPub(pub_Id);
            return Ok(titles);
        }

        [HttpGet("GetTitlesByUnderPrice")]
        public IActionResult GetTitlesByUnderPrice(decimal price)
        {
            var titles = this.titlesRepository.GetTitlesByUnderPrice(price);
            return Ok(titles);
        }

        [HttpGet("GetTitlesByOnPrice")]
        public IActionResult GetTitlesByOnPrice(decimal price)
        {
            var titles = this.titlesRepository.GetTitlesByOnPrice(price);
            return Ok(titles);
        }

        [HttpGet("GetTitleSalesByID")]
        public IActionResult GetTitleSalesByID(string id)
        {
            var titles = this.titlesRepository.GetTitleSalesByID(id);
            return Ok(titles);
        }
    }
}
