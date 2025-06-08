using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> InBox()
        {
            var user = await _userService.GetUserInfo();

            var messages = await _messageService.GetInboxMessageAsync(user.Id);

            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> SendBox()
        {
            var user = await _userService.GetUserInfo();

            var messages = await _messageService.GetSendboxMessageAsync(user.Id);

            return View(messages);
        }
    }
}
