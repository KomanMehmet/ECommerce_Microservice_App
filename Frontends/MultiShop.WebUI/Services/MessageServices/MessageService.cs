using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateMessageDto>("usermessages", createMessageDto);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _httpClient.DeleteAsync("usermessages/" + id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var response = await _httpClient.GetAsync("usermessages");

            var values = await response.Content.ReadFromJsonAsync<List<ResultMessageDto>>();

            return values;
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var response = await _httpClient.GetAsync("usermessages/" + id);

            var values = await response.Content.ReadFromJsonAsync<GetByIdMessageDto>();

            return values;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var response = await _httpClient.GetAsync("usermessages/GetMessageInBox/" + id);

            var values = await response.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();

            return values;
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var response = await _httpClient.GetAsync("usermessages/GetMessageSendBox/" + id);

            var values = await response.Content.ReadFromJsonAsync<List<ResultSendBoxMessageDto>>();

            return values;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateMessageDto>("usermessages", updateMessageDto);
        }
    }
}
