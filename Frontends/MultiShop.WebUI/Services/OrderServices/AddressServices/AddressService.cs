using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using MultiShop.WebUI.Services.OrderServices.GenericServices;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public class AddressService : OrderCrudService<ResultAddressDto, CreateAddressDto, UpdateAddressDto>, IAddressService
    {
        public AddressService(HttpClient httpClient) : base(httpClient, "addresses")
        {
        }
    }
}
