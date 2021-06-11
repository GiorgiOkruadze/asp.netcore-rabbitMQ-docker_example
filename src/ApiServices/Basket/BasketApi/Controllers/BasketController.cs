using BasketApi.Models;
using BasketApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasketApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public readonly IBasketRepository _repository = default;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<BasketController>
        [HttpGet("{userName}",Name ="GetBasket")]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var basket = await _repository.GetBasketsAsync(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        // PUT api/<BasketController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart value)
        {
            var response = await _repository.UpdateBasketAsync(value);
            return Ok(response);
        }

        // DELETE api/<BasketController>/5
        [HttpDelete("{userName}",Name ="DeleteBasket")]
        public async Task<IActionResult> Delete(string userName)
        {
            var response = await _repository.DeleteBasketAsync(userName);
            return Ok(response);
        }
    }
}
