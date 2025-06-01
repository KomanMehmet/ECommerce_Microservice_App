using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : CatalogCrudService<ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto>, IFeatureSliderService
    {
        public FeatureSliderService(HttpClient httpClient) : base(httpClient, "featuresliders")
        {
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }
    }
}
