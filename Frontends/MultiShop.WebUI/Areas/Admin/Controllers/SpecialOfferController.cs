using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Özel İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Özel İndirim Listesi";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7227/api/SpecialOffers");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            ViewBag.v0 = "Özel İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Yeni Özel İndirim Girişi";

            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7227/api/SpecialOffers", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new {area = "Admin"});
            }

            return View();
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7227/api/SpecialOffers?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v0 = "Özel İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Özel İndirim Güncelleme İşlemi";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7227/api/SpecialOffers/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7227/api/SpecialOffers", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin"});
            }

            return View();
        }
    }
}
