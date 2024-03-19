using JobSchedule.Domain.Entities;
using JobSchedule.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Api.Controllers
{
    [Route("api/Shops")]
    public class ShopController : Controller
    {
        private readonly IShopRepository _repository;

        public ShopController(IShopRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{skip?}/{take?}")]
        public async Task<IActionResult> GetAll(int? skip = null, int? take = null)
        {
            try
            {
                if (skip.HasValue && take.HasValue)
                    return Ok(await _repository.GetAll().Skip(skip.Value).Take(take.Value).ToListAsync());

                return Ok(await _repository.GetAll().ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Shop shop)
        {
            try
            {
                if (shop == null || string.IsNullOrEmpty(shop.Name))
                    return NoContent();

                shop = await _repository.Add(shop);

                return Ok(shop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Shop? entity = await _repository.FindByID(id);

                if (entity == null) return NoContent();

                await _repository.Delete(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
