using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : CatalogCrudService<ResultAboutDto, CreateAboutDto, UpdateAboutDto>, IAboutService
    {
        public AboutService(HttpClient httpClient) : base(httpClient, "abouts")
        {
        }
    }
}
