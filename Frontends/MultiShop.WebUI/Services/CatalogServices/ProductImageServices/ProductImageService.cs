using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : CatalogCrudService<ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto>, IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient) : base(httpClient, "productimages")
        {
            _httpClient = httpClient;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var response = await _httpClient.GetAsync("productimages/GetByProductIdProductImage/" + id);

            var value = await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();

            return value;
        }
    }
}
