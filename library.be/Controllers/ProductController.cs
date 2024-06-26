using library.be.Data;
using library.be.Models;
using library.be.Repository.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;   
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
           var response = await _productRepo.GetAllProducts();
           return Ok(response);
        }
        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productRepo.GetProductById(id);
            return Ok(result);
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] Product model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(model);
            }
            var product = new Product
            {
                Id = model.Id,
                ISBN = model.ISBN,
                Amount = model.Amount,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                Title = model.Title,
            };
            var result = await _productRepo.CreateOrUpdateProduct(product);
            return Ok(result);
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepo.DeleteProduct(id);
            return Ok(result);
        }
    }
}
