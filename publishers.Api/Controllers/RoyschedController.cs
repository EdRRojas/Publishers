using Microsoft.AspNetCore.Mvc;
using publishers.Api.Dtos.Roysched;
using publishers.Api.Models;
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

        //[HttpGet("GetRoyschedById")]
        //public IActionResult Get(string id)
        //{
        //    var roysched = this.royschedService.GetEntityById(id);
        //    RoyschedGetModel royschedGetModel = new RoyschedGetModel()
        //    {
        //        title_id = roysched.title_id,
        //        lorange = roysched.lorange,
        //        hirange = roysched.hirange,
        //        royalty = roysched.royalty,
        //    };
        //    return Ok (royschedGetModel);
        //}

        //[HttpPost ("SaveRoysched")]
        //public IActionResult Post([FromBody] RoyschedAddDto royschedGetModel)
        //{
        //    this.royschedService.Create(new Domain.Entities.roysched
        //    {
        //        title_id = royschedGetModel.title_id,
        //        lorange = royschedGetModel.lorange,
        //        hirange = royschedGetModel.hirange,
        //        royalty = royschedGetModel.royalty,
        //        CreationDate = royschedGetModel.CreationDate,
        //        CreationUser = royschedGetModel.CreationUser
        //    });

        //    return Ok ("Royshed guardado correctamente");
        //}


        //[HttpPost("UpdateRoysched")]
        //public IActionResult Put([FromBody]RoyschedUpdateDto royschedUpdateDto)
        //{
        //    this.royschedService.Update(new Domain.Entities.roysched()
        //    {
        //        title_id = royschedUpdateDto.title_id,
        //        lorange  = royschedUpdateDto.lorange,
        //        hirange  = royschedUpdateDto .hirange,
        //        royalty  = royschedUpdateDto .royalty,
        //        UserMod  = royschedUpdateDto .userMod,
        //        ModifyDate = royschedUpdateDto .modifyDate,
        //    });

        //    return Ok ("Royshed actualizado correctamente");
        //}

        //[HttpPost("RemoveRoysched")]
        //public IActionResult Remove([FromBody] RoyschedRemoveDto royschedRemoveDto)
        //{
        //        this.royschedService.Remove(new Domain.Entities.roysched()
        //        {
        //            title_id=royschedRemoveDto.title_id,
        //            royalty = royschedRemoveDto.royalty,
        //            hirange=royschedRemoveDto .hirange,
        //            lorange=royschedRemoveDto .lorange,
        //            UserDeleted = royschedRemoveDto.userDelete,
        //            DeleteTime = royschedRemoveDto .deleteTime,
        //            Deleted = royschedRemoveDto.deleted
        //        });
        //    return Ok("Royshed eliminado correctamente");

        //}
    }
}
