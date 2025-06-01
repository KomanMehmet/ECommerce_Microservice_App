using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService : ICatalogCrudService<ResultBrandDto, CreateBrandDto, UpdateBrandDto>
    {
    }
}
