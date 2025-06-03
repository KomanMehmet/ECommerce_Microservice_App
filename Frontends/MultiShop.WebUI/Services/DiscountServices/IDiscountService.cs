using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();

        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);

        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);

        Task DeleteDiscountCouponAsync(int couponId);

        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId);

        Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string couponCode);
    }
}
