
namespace MultiShop.WebUI.Services.StatisticServices.IdentityStatisticServices
{
    public class IdentityStatisticService : IIdentityStatisticService
    {
        private readonly HttpClient _httpClient;

        public IdentityStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalUserCountAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/Statistics");

            var userCount = await response.Content.ReadFromJsonAsync<int>();

            return userCount;
        }
    }
}
