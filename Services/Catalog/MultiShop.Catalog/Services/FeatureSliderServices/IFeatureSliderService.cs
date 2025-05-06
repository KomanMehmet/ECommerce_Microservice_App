using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureAsync();

        Task CreateFeatureAsync(CreateFeatureSliderDto createFeatureSliderDto);

        Task UpdateFeatureAsync(UpdateFeatureSliderDto updateFeatureSliderDto);

        Task DeleteFeatureAsync(string id);

        Task<GetByIdFeatureSliderDto> GetByIdFeatureAsync(string id);

        Task FeatureSliderChangeStatusToTrue(string id);

        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
