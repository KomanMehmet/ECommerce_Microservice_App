using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ComfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ComfirmDiscountCoupon(string code)
        {
            var discountRate = await _discountService.GetDiscountRateByCode(code);

            var basket = await _basketService.GetBasket();

            var tax = basket.TotalPrice * 0.18m;

            var generalTotal = basket.TotalPrice + tax;

            var totalNewPriceWithDiscount = generalTotal - (generalTotal / 100 * discountRate);

            //ViewBag.totalPriceWithDiscount = totalNewPriceWithDiscount;

            return RedirectToAction("Index", "ShoppingCart", new {code = code, discountRate = discountRate, totalPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
