using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService : ICatalogCrudService<ResultAboutDto, CreateAboutDto, UpdateAboutDto>
    {
    }
}
