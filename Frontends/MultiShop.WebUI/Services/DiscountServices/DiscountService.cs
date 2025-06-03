using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDiscountCouponAsync(int couponId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string couponCode)
        {
            var response = await _httpClient.GetAsync("http://localhost:7228/api/Discounts/GetCodeDetailByCode?code=" + couponCode);

            var values = await response.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();

            return values;
        }

        public Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}
