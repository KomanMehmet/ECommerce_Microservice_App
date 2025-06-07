using MultiShop.DtoLayer.OrderDtos.OrderingDtos;
using MultiShop.WebUI.Services.OrderServices.GenericServices;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
    public class OrderingService : OrderCrudService<ResultOrderDto, CreateOrderDto, UpdateOrderDto>, IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient) : base(httpClient, "orderings")
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            var response = await _httpClient.GetAsync($"orderings/GetOrderingByUserId?id={id}");

            var values = await response.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();

            return values;
        }
    }
}
