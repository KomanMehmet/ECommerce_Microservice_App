using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v1 = "Ürünler";
            ViewBag.v1 = "Ürünler Listesi";
            ViewBag.v1 = "Ürün İşlemleri";

            var values = await _productService.GetAllProductAsync();

            return View(values);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v1 = "Ürünler";
            ViewBag.v1 = "Ürün Ekleme";
            ViewBag.v1 = "Ürün İşlemleri";

            var categoryValues = await _categoryService.GetAllCategoryAsync();

            /*List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                         Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;*/
            ViewBag.CategoryValues = categoryValues.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryID
            }).ToList();

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);

            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);

            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme İşlemi";

            var categoriyValues = await _categoryService.GetAllCategoryAsync();

            ViewBag.CategoryValues1 = categoriyValues.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryID
            }).ToList();

            var productValue = await _productService.GetByIdProductAsync(id);

            return View(productValue);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);

            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün İşlemleri";

            var values = await _productService.GetProductWithCategoryAsync();

            return View(values);
        }
    }
}
