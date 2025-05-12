using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("ProductImagesDetail/{id}")]
        public async Task<IActionResult> ProductImagesDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
            ViewBag.v4 = "Ürün Görsel İşlemleri";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7227/api/ProductImages/GetByProductIdProductImage?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDAta = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<GetByProductIdProductImageDto>(jsonDAta);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("ProductImagesDetail/{id}")]
        public async Task<IActionResult> ProductImagesDetail(GetByProductIdProductImageDto getByProductIdProductImageDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(getByProductIdProductImageDto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7227/api/ProductImages", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new {area = "Admin"});
            }

            return View();
        }
    }
}
