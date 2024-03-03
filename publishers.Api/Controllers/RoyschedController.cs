using Microsoft.AspNetCore.Mvc;
using publishers.Api.Models;
using publishers.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publishers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyschedController : ControllerBase
    {
        private readonly IRoyschedRepository royschedRepository;
        public RoyschedController(IRoyschedRepository royschedRepository)
        {
            this.royschedRepository = royschedRepository;
        }

        [HttpGet ("GetRoysched")]
        public IActionResult Get()
        {
            var royscheds = this.royschedRepository.GetEntities();
            return Ok (royscheds);
        }

        [HttpGet("GetRoyschedById")]
        public IActionResult Get(string id)
        {
            var roysched = this.royschedRepository.GetEntityById(id);
            return Ok (roysched);
        }

        // POST api/<RoyschedController>
        [HttpPost ("SaveRoysched")]
        public void Post([FromBody] RoyschedAddModel royschedAddModel)
        {
            this.royschedRepository.Create(new Domain.Entities.roysched
            {
                title_id = royschedAddModel.title_id,
                lorange = royschedAddModel.lorange,
                hirange = royschedAddModel.hirange,
                royalty = royschedAddModel.royalty,
                CreationDate = royschedAddModel.CreationDate,
                CreationUser = royschedAddModel.CreationUser
            });
        }

        // PUT api/<RoyschedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoyschedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
