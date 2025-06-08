using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _httpClient.PostAsJsonAsync("cargocustomers", createCargoCustomerDto);
        }

        public async Task DeleteCargoCustomerAsync(int id)
        {
            await _httpClient.DeleteAsync($"cargocustomers/{id}");
        }

        public async Task<List<ResultCargoCustomerDto>> GetAllCargoCustomerAsync()
        {
            var response = await _httpClient.GetAsync("cargocustomers");

            var values = await response.Content.ReadFromJsonAsync<List<ResultCargoCustomerDto>>();

            return values;
        }

        public async Task<UpdateCargoCustomerDto> GetCargoCustomerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"cargocustomers/{id}");

            var values = await response.Content.ReadFromJsonAsync<UpdateCargoCustomerDto>();

            return values;
        }

        public async Task<GetCargoCustomerByUserIdDto> GetCargoCustomerByUserIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"cargocustomers/GetCargoCustomerByUserId/{id}");

            var values = await response.Content.ReadFromJsonAsync<GetCargoCustomerByUserIdDto>();

            return values;
        }

        public async Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _httpClient.PutAsJsonAsync("cargocustomers", updateCargoCustomerDto);
        }
    }
}
