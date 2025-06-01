using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService : ICatalogCrudService<ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto>
    {
        Task FeatureSliderChangeStatusToTrue(string id);

        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
