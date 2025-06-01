using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : CatalogCrudService<ResultProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto>, IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient) : base(httpClient, "productdetails")
        {
            _httpClient = httpClient;
        }

        public async Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string id)
        {
            var response = await _httpClient.GetAsync("productdetails/GetProductDetailByProductId/" + id);

            var value = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();

            return value;
        }
    }
}
