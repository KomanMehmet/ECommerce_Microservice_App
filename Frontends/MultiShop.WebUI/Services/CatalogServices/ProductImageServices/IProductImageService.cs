using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService : ICatalogCrudService<ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto>
    {
        Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
    }
}
