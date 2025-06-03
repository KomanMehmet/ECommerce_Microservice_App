using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos.Dtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            @ViewBag.directory1 = "Ana Sayfa";
            @ViewBag.directory2 = "Ürünler";
            @ViewBag.directory3 = "Sepetim";

            return View();
        }

        public async Task<IActionResult> AddToBasket(string id)
        {
            var product = await _productService.GetByIdAsync(id);

            var items = new BasketItemDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.ProductPrice,
                Quantity = 1,
                ProductImageUrl = product.ProductImageURL
            };

            await _basketService.AddBasketItem(items);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromBasket(string id)
        {
            await _basketService.RemoveBasketItem(id);

            return RedirectToAction("Index");
        }
    }
}
