using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public UserMessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMessagesAsync()
        {
            var values = await _messageService.GetAllMessageAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessageByIdAsync(int id)
        {
            var value = await _messageService.GetByIdMessageAsync(id);

            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserMessageAsync(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);

            return Ok("Message created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _messageService.UpdateMessageAsync(updateMessageDto);

            return Ok("Message updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMessageAsync(int id)
        {
            await _messageService.DeleteMessageAsync(id);

            return Ok("Message deleted successfully.");
        }

        [HttpGet("GetMessageSendBox/{id}")]
        public async Task<IActionResult> GetMessageSendBoxAsync(string id)
        {
            var values = await _messageService.GetSendboxMessageAsync(id);

            return Ok(values);
        }

        [HttpGet("GetMessageInBox/{id}")]
        public async Task<IActionResult> GetMessageInBox(string id)
        {
            var values = await _messageService.GetInboxMessageAsync(id);

            return Ok(values);
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int messageCount = await _messageService.GetTotalMessageCountAsync();

            return Ok(messageCount);
        }

        [HttpGet("GetTotalMessageByReceiverIdCount/{id}")]
        public async Task<IActionResult> GetTotalMessageByReceiverIdCount(string id)
        {
            int messageByReceiverCount = await _messageService.GetTotalMessageCountByReceiverId(id);

            return Ok(messageByReceiverCount);
        }
    }
}
