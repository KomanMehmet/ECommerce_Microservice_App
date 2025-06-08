using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync("cargocompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync($"cargocompanies?id={id}");
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompaniesAsync()
        {
            var response = await _httpClient.GetAsync("cargocompanies");

            var values = await response.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();

            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetCargoCompanyByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"cargocompanies/{id}");

            var values = await response.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();

            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync("cargocompanies", updateCargoCompanyDto);
        }
    }
}
