
using Newtonsoft.Json;

namespace MultiShop.SignalRRealTimeApi.Services.CommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:7232/api/CommentStatistics");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var commentCount = JsonConvert.DeserializeObject<int>(jsonData);

            return commentCount;
        }
    }
}
