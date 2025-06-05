using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using MultiShop.WebUI.Services.OrderServices.GenericServices;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService : IOrderCrudService<ResultAddressDto, CreateAddressDto, UpdateAddressDto>
    {
       
    }
}
