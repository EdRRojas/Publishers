using Microsoft.AspNetCore.Mvc;
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
        public void Post([FromBody] TitlesAddModel titlesAddModel)
        {
            this.titlesRepository.Create(new publishers.Domain.Entities.Titles()
            {
                title_id = titlesAddModel.title_id,
                title = titlesAddModel.title,
                type = titlesAddModel.type,
                pub_id = titlesAddModel.pub_id,
                price = titlesAddModel.price,
                advance = titlesAddModel.advance,
                royalty = titlesAddModel.royalty,
                ytd_sales = titlesAddModel.ytd_sales,
                notes = titlesAddModel.notes,
                pubdate = titlesAddModel.pubdate,
                creationUser = titlesAddModel.creationUser,
                creationDate = titlesAddModel.creationDate
            });
        }

        // PUT api/<TitlesController>/5
        [HttpPut("TitlesUpdate")]
        public void Put([FromBody] TitlesAddModel titlesAddModel)
        {
        }

        // DELETE api/<TitlesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
