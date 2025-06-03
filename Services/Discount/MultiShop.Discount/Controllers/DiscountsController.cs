using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponGetById(int id)
        {
            var values = await _discountService.GetByIdDiscountCouponAsync(id);

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);

            return Ok("Coupon başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);

            return Ok("Coupon başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);

            return Ok("Coupon başarıyla silindi");
        }

        [HttpGet("GetCodeDetailByCode")]
        public async Task<IActionResult> GetCodeDetailByCode(string code)
        {
            var values = await _discountService.GetDiscountCodeAsync(code);

            if (values == null)
            {
                return NotFound("Coupon bulunamadı");
            }
            return Ok(values);
        }

        [HttpGet("GetDiscountRateByCode")]
        public IActionResult GetDiscountRateByCode(string code)
        {
            var values =  _discountService.GetDiscountRateByCode(code);

            if (values == null)
            {
                return NotFound("Coupon bulunamadı");
            }
            return Ok(values);
        }
    }
}
