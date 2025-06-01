using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService : ICatalogCrudService<ResultFeatureDto, CreateFeatureDto, UpdateFeatureDto>
    {
    }
}
