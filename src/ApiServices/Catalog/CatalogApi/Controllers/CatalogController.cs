using CatalogApi.DBContext;
using CatalogApi.Models;
using CatalogApi.Repositories;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository = default;
        private readonly ILogger<CatalogController> _logger = default;

        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/<CatalogController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetProductsAsync();
            return Ok(data);
        }

        // GET api/<CatalogController>/5
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _repository.GetProductAsync(id);

            if(data == null)
            {
                _logger.LogError($"Can't get product with id {id}");
                return NotFound();
            }

            return Ok(data);
        }


        // GET api/<CatalogController>/5
        [HttpGet]
        [Route("[action]/{name}", Name = "GetProductByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await _repository.GetProductByNameAsync(name);

            if (data == null)
            {
                _logger.LogError($"Can't get product with name {name}");
                return NotFound();
            }

            return Ok(data);
        }

        // GET api/<CatalogController>/5
        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductsByCategory")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var data = await _repository.GetProductByCategoryAsync(category);

            if (data == null)
            {
                _logger.LogError($"Can't get product with category {category}");
                return NotFound();
            }

            return Ok(data);
        }


        // POST api/<CatalogController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product value)
        {
            var response = await _repository.CreateProductAsync(value);

            return CreatedAtRoute("GetProductById", new { id = value.Id }, value);
        }

        // PUT api/<CatalogController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product value)
        {
            var response = await _repository.UpdateProductAsync(value);
            return Ok(response);
        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _repository.DeleteProductAsync(id);
            return Ok(response);
        }
    }
}
