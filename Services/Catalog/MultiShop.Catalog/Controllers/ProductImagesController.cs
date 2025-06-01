using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var result = await _productImageService.GetAllProductImageAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductImage(string id)
        {
            var result = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto productImageDto)
        {
            await _productImageService.CreateProductImageAsync(productImageDto);
            return Ok("Product image created successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Product image deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto productImageDto)
        {
            await _productImageService.UpdateProductImageAsync(productImageDto);
            return Ok("Product image updated successfully.");
        }

        [HttpGet("GetByProductIdProductImage/{id}")]
        public async Task<IActionResult> GetByProductIdProductImage(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);

            return Ok(values);
        }
    }
}
