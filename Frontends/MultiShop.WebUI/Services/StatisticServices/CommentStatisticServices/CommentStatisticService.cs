
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            var response = await _httpClient.GetAsync("Comments/GetActiveCommentCount");

            var activeCommentCount = await response.Content.ReadFromJsonAsync<int>();

            return activeCommentCount;
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            var response = await _httpClient.GetAsync("Comments/GetPassiveCommentCount");

            var activeCommentCount = await response.Content.ReadFromJsonAsync<int>();

            return activeCommentCount;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            var response = await _httpClient.GetAsync("Comments/GetTotalCommentCount");

            var activeCommentCount = await response.Content.ReadFromJsonAsync<int>();

            return activeCommentCount;
        }
    }
}
