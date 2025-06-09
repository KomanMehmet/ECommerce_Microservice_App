namespace MultiShop.WebUI.Services.StatisticServices.IdentityStatisticServices
{
    public interface IIdentityStatisticService
    {
        Task<int> GetTotalUserCountAsync();
    }
}
