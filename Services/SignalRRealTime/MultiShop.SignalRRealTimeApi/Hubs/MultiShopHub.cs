using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.CommentServices;
using MultiShop.SignalRRealTimeApi.Services.MessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{

    public class MultiShopHub : Hub
    {
        //private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public MultiShopHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var totalCommentCount = await _signalRCommentService.GetTotalCommentCountAsync();
            await Clients.All.SendAsync("ReceiveTotalCommentCount", totalCommentCount);

            //var totalMessageCount = await _signalRMessageService.GetTotalMessageByReceiverIdCountAsync(receiverId);
            //await Clients.All.SendAsync("ReceiveTotalMessageCount", totalMessageCount);
        }
    }
}
