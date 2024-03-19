using Microsoft.AspNetCore.Mvc;
using publishers.Api.Dtos.Roysched;
using publishers.Api.Models;
using publishers.Infrastructure.Exceptions;
using publishers.Infrastructure.Interfaces;


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

        [HttpGet ("GetRoyscheds")]
        public IActionResult Get()
        {
            var royscheds = this.royschedRepository.GetEntities().Select(ro => new RoyschedGetModel()
            {
                title_id = ro.title_id,
                lorange = ro.lorange,
                hirange = ro.hirange,
                royalty = ro.royalty,
            });

            return Ok (royscheds);
        }

        [HttpGet("GetRoyschedById")]
        public IActionResult Get(string id)
        {
            var roysched = this.royschedRepository.GetEntityById(id);
            RoyschedGetModel royschedGetModel = new RoyschedGetModel()
            {
                title_id = roysched.title_id,
                lorange = roysched.lorange,
                hirange = roysched.hirange,
                royalty = roysched.royalty,
            };
            return Ok (royschedGetModel);
        }

        [HttpPost ("SaveRoysched")]
        public IActionResult Post([FromBody] RoyschedAddDto royschedGetModel)
        {
            this.royschedRepository.Create(new Domain.Entities.roysched
            {
                title_id = royschedGetModel.title_id,
                lorange = royschedGetModel.lorange,
                hirange = royschedGetModel.hirange,
                royalty = royschedGetModel.royalty,
                CreationDate = royschedGetModel.CreationDate,
                CreationUser = royschedGetModel.CreationUser
            });

            return Ok ("Royshed guardado correctamente");
        }


        [HttpPost("UpdateRoysched")]
        public IActionResult Put([FromBody]RoyschedUpdateDto royschedUpdateDto)
        {
            this.royschedRepository.Update(new Domain.Entities.roysched()
            {
                title_id = royschedUpdateDto.title_id,
                lorange  = royschedUpdateDto.lorange,
                hirange  = royschedUpdateDto .hirange,
                royalty  = royschedUpdateDto .royalty,
                UserMod  = royschedUpdateDto .userMod,
                ModifyDate = royschedUpdateDto .modifyDate,
            });

            return Ok ("Royshed actualizado correctamente");
        }

        [HttpPost("RemoveRoysched")]
        public IActionResult Remove([FromBody] RoyschedRemoveDto royschedRemoveDto)
        {
                this.royschedRepository.Remove(new Domain.Entities.roysched()
                {
                    title_id=royschedRemoveDto.title_id,
                    royalty = royschedRemoveDto.royalty,
                    hirange=royschedRemoveDto .hirange,
                    lorange=royschedRemoveDto .lorange,
                    UserDeleted = royschedRemoveDto.userDelete,
                    DeleteTime = royschedRemoveDto .deleteTime,
                    Deleted = royschedRemoveDto.deleted
                });
            return Ok("Royshed eliminado correctamente");

        }
    }
}
