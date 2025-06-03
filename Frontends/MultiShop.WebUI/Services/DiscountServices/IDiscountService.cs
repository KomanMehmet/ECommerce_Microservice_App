using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string couponCode);

        Task<int> GetDiscountRateByCode(string couponCode);
    }
}
