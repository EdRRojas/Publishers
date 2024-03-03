using Microsoft.AspNetCore.Mvc;
using publishers.Domain.Entities;
using publishers.Infrastructure.Interfaces;

namespace publishers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreRepository _storeRepository, ILogger<StoreController> logger)
        {
            this._storeRepository = _storeRepository;
            _logger = logger;
        }

        // GET: api/Store
        [HttpGet]
        public IActionResult Get()
        {
            var stores = this._storeRepository.GetEntities();
            return Ok(stores);
        }

        // GET: api/Store/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var store = _storeRepository.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        // POST: api/Store
        [HttpPost]
        public IActionResult Post([FromBody] Store store)
        {
            _storeRepository.Create(store);
            return CreatedAtAction(nameof(Get), new { id = store.stor_id }, store);
        }

        // PUT: api/Store/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Store store)
        {
            _storeRepository.Update(store);
            return NoContent();
        }

        // DELETE: api/Store/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var store = _storeRepository.GetStoreById(id);
                if (store == null)
                {
                    return NotFound();
                }

                _storeRepository.Remove(store);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting store with id {0}: {1}", id, ex);
                return StatusCode(500, ex);
            }
        }
    }
}
