using Microsoft.AspNetCore.Mvc;
using publishers.Api.Models;
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

        [HttpGet("GetDiscounts")]
        public IActionResult Get()
        {
            var discounts = this.discountsRepository.GetEntities();
            return Ok(discounts);
        }

        // GET api/<DiscountsController>/5
        [HttpGet("GetDiscountByID")]
        public IActionResult GetDiscountByID (int id)
        {
            var discount = this.discountsRepository.GetEntities();
            return Ok(discount);
        }

        // POST api/<DiscountsController>
        [HttpPost("SaveDiscounts")]
        public void Post([FromBody]DiscountsAddModel discountsAddModel)
        {

            this.discountsRepository.create(new Domain.Entities.Discounts()
            {

                discounttype = discountsAddModel.discounttype,
                stor_id = discountsAddModel.stor_id,
                lowqty = discountsAddModel.lowqty,
                highqty = discountsAddModel.highqty,
                discount = discountsAddModel.discount,
                creationUser = discountsAddModel.creationUser,
                creationDate = discountsAddModel.creationDate,
            }); 
        }
        // PUT api/<DiscountsController>/5
        [HttpPut("DiscountsUpdate")]
        public void Put([FromBody] DiscountsAddModel discountsAddModel )
        {
            this.discountsRepository.update(new Domain.Entities.Discounts()
            {
                discounttype = discountsAddModel.discounttype,
                discount = discountsAddModel.discount,
                lowqty = discountsAddModel.lowqty,
                highqty = discountsAddModel.highqty,
            });
        }

        // DELETE api/<DiscountsController>/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] DiscountsAddModel discountsAddModel)
        {
            this.discountsRepository.remove(new Domain.Entities.Discounts()
            {
                discounttype = discountsAddModel.discounttype,
                deleted = true,
                userDeleted = discountsAddModel.creationUser,
                deteleTime = discountsAddModel.creationDate
            }) ;
        }
    }
}
