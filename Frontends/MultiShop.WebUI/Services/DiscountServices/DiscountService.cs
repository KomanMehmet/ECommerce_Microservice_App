using MultiShop.DtoLayer.DiscountDtos;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string couponCode)
        {
            var response = await _httpClient.GetAsync("http://localhost:7228/api/Discounts/GetCodeDetailByCode?code=" + couponCode);

            var values = await response.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();

            return values;
        }

        public async Task<int> GetDiscountRateByCode(string couponCode)
        {
            var response = await _httpClient.GetAsync("http://localhost:7228/api/Discounts/GetDiscountRateByCode?code=" + couponCode);

            var values = await response.Content.ReadFromJsonAsync<int>();

            return values;
        }
    }
}
