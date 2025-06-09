

namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public class DiscountStatisticService : IDiscountStatisticService
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            var response = await _httpClient.GetAsync("discounts/GetDiscountCouponCount");

            var discountCouponCount = await response.Content.ReadFromJsonAsync<int>();

            return discountCouponCount;
        }
    }
}
