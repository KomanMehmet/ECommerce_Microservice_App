using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;
using MultiShop.Catalog.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ICatalogStatisticService _statisticService;

        public StatisticsController(ICatalogStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetTotalBrands")]
        public async Task<IActionResult> GetTotalBrands()
        {
            var values = await _statisticService.GetTotalBrandsAsync();

            return Ok(values);
        }

        [HttpGet("GetTotalCategories")]
        public async Task<IActionResult> GetTotalCategories()
        {
            var values = await _statisticService.GetTotalCategoriesAsync();

            return Ok(values);
        }

        [HttpGet("GetTotalProducts")]
        public async Task<IActionResult> GetTotalProducts()
        {
            var values = await _statisticService.GetTotalProductsAsync();

            return Ok(values);
        }

        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var values = await _statisticService.GetProductAvgPriceAsync();

            return Ok(values);
        }

        [HttpGet("GetMaxPriceProductsName")]
        public async Task<IActionResult> GetMaxPriceProductsName()
        {
            var values = await _statisticService.GetMaxPriceProductsName();

            return Ok(values);
        }

        [HttpGet("GetMinPriceProductsName")]
        public async Task<IActionResult> GetMinPriceProductsName()
        {
            var values = await _statisticService.GetMinPriceProductsName();

            return Ok(values);
        }
    }
}
