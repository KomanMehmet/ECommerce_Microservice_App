
namespace MultiShop.WebUI.Services.CatalogServices.GenericServices
{
    public class CatalogCrudService<TDto, TCreateDto, TUpdateDto> : ICatalogCrudService<TDto, TCreateDto, TUpdateDto>
    {
        private readonly HttpClient _httpClient;
        private readonly string _endPoint;

        public CatalogCrudService(HttpClient httpClient, string endPoint)
        {
            _httpClient = httpClient;
            _endPoint = endPoint;
        }

        public async Task CreateAsync(TCreateDto createDto)
        {
            await _httpClient.PostAsJsonAsync<TCreateDto>(_endPoint, createDto);
        }

        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"{_endPoint}?id={id}");
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_endPoint);

            var values = await response.Content.ReadFromJsonAsync<List<TDto>>();

            return values;
        }

        public async Task<TUpdateDto> GetByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{_endPoint}/{id}");

            var value = await response.Content.ReadFromJsonAsync<TUpdateDto>();

            return value;
        }

        public async Task UpdateAsync(TUpdateDto updateDto)
        {
            await _httpClient.PutAsJsonAsync(_endPoint, updateDto);
        }
    }
}
