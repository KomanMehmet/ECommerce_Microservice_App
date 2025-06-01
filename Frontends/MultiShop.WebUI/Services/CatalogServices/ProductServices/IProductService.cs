using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService : ICatalogCrudService<ResultProductDto, CreateProductDto, UpdateProductDto>
    {
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync();

        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryId);
    }
}
