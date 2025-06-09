namespace MultiShop.SignalRRealTimeApi.Services.MessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageByReceiverIdCountAsync(string id)
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/services/Message/usermessages/GetTotalMessageByReceiverIdCount/" + id);

            var values = await response.Content.ReadFromJsonAsync<int>();

            return values;
        }
    }
}
