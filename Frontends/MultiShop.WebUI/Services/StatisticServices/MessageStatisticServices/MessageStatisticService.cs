
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            var response = await _httpClient.GetAsync("usermessages/GetTotalMessageCount");

            var totalMessageCount = await response.Content.ReadFromJsonAsync<int>();

            return totalMessageCount;
        }
    }
}
