using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpacialOfferServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Özel İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Özel İndirim Listesi";

            var values = await _specialOfferService.GetAllAsync();

            return View(values);
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
            await _specialOfferService.CreateAsync(createSpecialOfferDto);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteAsync(id);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v0 = "Özel İndirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel İndirimler";
            ViewBag.v3 = "Özel İndirim Güncelleme İşlemi";

            var value = await _specialOfferService.GetByIdAsync(id);

            return View(value);
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateAsync(updateSpecialOfferDto);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
