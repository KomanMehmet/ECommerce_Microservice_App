using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> GetAllCargoCustomerAsync();

        Task<UpdateCargoCustomerDto> GetCargoCustomerByIdAsync(int id);

        Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto);

        Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto);

        Task DeleteCargoCustomerAsync(int id);

        Task<GetCargoCustomerByUserIdDto> GetCargoCustomerByUserIdAsync(string id);
    }
}
