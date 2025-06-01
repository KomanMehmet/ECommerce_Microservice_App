using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : CatalogCrudService<ResultBrandDto, CreateBrandDto, UpdateBrandDto>, IBrandService
    {
        public BrandService(HttpClient httpClient) : base(httpClient, "brands")
        {
        }
    }
}
