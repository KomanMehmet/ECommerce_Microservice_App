using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginSercie)
        {
            _basketService = basketService;
            _loginService = loginSercie;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;//sisteme girmiş olan tokena ait bilgileri verecek.

            var values = await _basketService.GetBasket(_loginService.GetUserId);

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserID = _loginService.GetUserId;

            await _basketService.SaveBasket(basketTotalDto);

            return Ok("Successfully saved basket.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);

            return Ok("Successfully delete basket");
        }
    }
}
