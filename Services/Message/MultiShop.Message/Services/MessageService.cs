using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccessLayer.Context;
using MultiShop.Message.DataAccessLayer.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public MessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<UserMessage>(createMessageDto);

            await _messageContext.UserMessages.AddAsync(values);

            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);

            if (values == null)
                throw new KeyNotFoundException($"Message with id {id} not found.");

            _messageContext.UserMessages.Remove(values);

            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.AsNoTracking().ToListAsync();

            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.AsNoTracking().FirstOrDefaultAsync(x => x.UserMessageID == id);
                
            return _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).AsNoTracking().ToListAsync();

            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderID == id).AsNoTracking().ToListAsync();

            return _mapper.Map<List<ResultSendBoxMessageDto>>(values);
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            int messageCount = await _messageContext.UserMessages.CountAsync();

            return messageCount;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var existing = await _messageContext.UserMessages.FindAsync(updateMessageDto.UserMessageID);

            if (existing == null)
                throw new KeyNotFoundException($"Message with id {updateMessageDto.UserMessageID} not found.");

            _mapper.Map(updateMessageDto, existing);

            await _messageContext.SaveChangesAsync();
        }
    }
}
