using MultiShop.DtoLayer.OrderDtos.OrderingDtos;
using MultiShop.WebUI.Services.OrderServices.GenericServices;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService : IOrderCrudService<ResultOrderDto, CreateOrderDto, UpdateOrderDto>
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
