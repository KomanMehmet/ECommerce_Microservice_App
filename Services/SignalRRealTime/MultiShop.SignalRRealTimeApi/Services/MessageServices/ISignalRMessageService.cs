namespace MultiShop.SignalRRealTimeApi.Services.MessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageByReceiverIdCountAsync(string id);
    }
}
