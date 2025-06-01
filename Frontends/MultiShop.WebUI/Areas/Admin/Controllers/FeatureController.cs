using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Özellik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellikler Listesi";

            var values = await _featureService.GetAllAsync();

            return View(values);
        }

        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {
            ViewBag.v0 = "Özellik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Yeni Özellik Girişi";

            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateAsync(createFeatureDto);

            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v0 = "Özellik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellik Güncelleme İşlemi";

            var value = await _featureService.GetByIdAsync(id);

            return View(value);
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateAsync(updateFeatureDto);

            return RedirectToAction("Index", "Feature", new { ares = "Admin" });
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteAsync(id);

            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
    }
}
