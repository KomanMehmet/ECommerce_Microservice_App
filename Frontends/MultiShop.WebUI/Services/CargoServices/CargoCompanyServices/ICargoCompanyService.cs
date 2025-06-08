using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync();

        Task<UpdateCargoCompanyDto> GetCargoCompanyByIdAsync(int id);

        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);

        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);

        Task DeleteCargoCompanyAsync(int id);
    }
}
