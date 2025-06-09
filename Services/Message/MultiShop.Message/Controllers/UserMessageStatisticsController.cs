using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public UserMessageStatisticsController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMessageCount()
        {
            var values = await _messageService.GetTotalMessageCountAsync();

            return Ok(values);
        }
    }
}
