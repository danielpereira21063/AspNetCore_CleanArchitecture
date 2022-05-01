using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null)
            {
                return NotFound("Products not found.");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO data)
        {
            if (data == null)
            {
                return BadRequest("Invalid data.");
            }

            _productService.AddAsync(data);

            return new CreatedAtRouteResult("Getproduct", new { id = data.Id }, data);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }

            if (data == null)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(data);

            return Ok(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.RemoveAsync(id);
            return Ok(product);
        }
    }
}
