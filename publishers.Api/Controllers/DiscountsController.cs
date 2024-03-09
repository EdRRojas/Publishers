using Microsoft.AspNetCore.Mvc;
using publishers.Api.Dtos.Discounts;
using publishers.Infrastructure.Interface;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publishers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountsRepository discountsRepository;
        public DiscountsController(IDiscountsRepository discountsRepository)
        {
            this.discountsRepository = discountsRepository;
        }

        [HttpGet("GetdiscounttypeByName")]
        public IActionResult Get(string name)
        {
            var discounts = this.discountsRepository.GetEntities(name);
            return Ok(discounts);
        }

        // GET api/<DiscountsController>/5
        [HttpGet("GetDiscountByID")]
        public IActionResult GetDiscountByID (string id)
        {
            var discount = this.discountsRepository.GetEntities(id);
            return Ok(discount);
        }

        // POST api/<DiscountsController>
        [HttpPost("SaveDiscounts")]
        public void Post([FromBody]DiscountsAddDtos discountsAddDtos)
        {

            this.discountsRepository.create(new Domain.Entities.Discounts()
            {

                discounttype = discountsAddDtos.discounttype,
                stor_id = discountsAddDtos.stor_id,
                lowqty = discountsAddDtos.lowqty,
                highqty = discountsAddDtos.highqty,
                discount = discountsAddDtos.discount,
                
                
            }); 
        }
        // PUT api/<DiscountsController>/5
        [HttpPut("DiscountsUpdate")]
        public void Put([FromBody] DiscountsUpdateDtos discountsUpdateDtos )
        {
            this.discountsRepository.update(new Domain.Entities.Discounts()
            {
                discounttype = discountsUpdateDtos.discounttype,
                discount = discountsUpdateDtos.discount,
                lowqty = discountsUpdateDtos.lowqty,
                highqty = discountsUpdateDtos.highqty,
                
            });
        }

        // DELETE api/<DiscountsController>/5
        [HttpDelete("DiscountsRemove")]
        public void Delete([FromBody] DiscountsDtosDelete discountsDtosDelete)
        {
            this.discountsRepository.remove(new Domain.Entities.Discounts()
            {
                discounttype = discountsDtosDelete.discounttype,
                deteled = 0,
                userDeleted = discountsDtosDelete.creationUser,
                deteleTime = discountsDtosDelete.creationDate
            }) ;
        }
        
    }



}
