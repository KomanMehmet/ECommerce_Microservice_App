using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService : ICatalogCrudService<ResultProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto>
    {
        Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string id);
    }
}
