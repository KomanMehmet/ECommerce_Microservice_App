using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : CatalogCrudService<ResultProductDto, CreateProductDto, UpdateProductDto>, IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient) : base(httpClient, "products")
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/getproductwithcategory");

            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();

            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await _httpClient.GetAsync("products/getproductwithcategorybycategoryid?categoryid=" + categoryId);

            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();

            return values;
        }
    }
}
