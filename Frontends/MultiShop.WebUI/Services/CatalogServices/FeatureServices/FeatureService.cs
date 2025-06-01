using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : CatalogCrudService<ResultFeatureDto, CreateFeatureDto, UpdateFeatureDto>, IFeatureService
    {
        public FeatureService(HttpClient httpClient) : base(httpClient, "features")
        {
        }
    }
}
