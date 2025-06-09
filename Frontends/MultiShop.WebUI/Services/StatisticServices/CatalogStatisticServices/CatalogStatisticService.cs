
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetMaxPriceProductsName()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductsName"); 

            var values = await responseMessage.Content.ReadAsStringAsync();

            return values;
        }

        public async Task<string> GetMinPriceProductsName()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductsName");

            var values = await responseMessage.Content.ReadAsStringAsync();

            return values;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductAvgPrice");

            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();

            return values;
        }

        public async Task<long> GetTotalBrandsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetTotalBrands");

            var values = await responseMessage.Content.ReadFromJsonAsync<long>();

            return values;
        }

        public async Task<long> GetTotalCategoriesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetTotalCategories");

            var values = await responseMessage.Content.ReadFromJsonAsync<long>();

            return values;
        }

        public async Task<long> GetTotalProductsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetTotalProducts");

            var values = await responseMessage.Content.ReadFromJsonAsync<long>();

            return values;
        }
    }
}
