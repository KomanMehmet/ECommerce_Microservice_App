using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();

        Task CreateMessageAsync(CreateMessageDto createMessageDto);

        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);

        Task DeleteMessageAsync(int id);

        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);

        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);

        Task<List<ResultSendBoxMessageDto>> GetSendboxMessageAsync(string id);

        Task<int> GetTotalMessageByReceiverIdCountAsync(string id);
    }
}
