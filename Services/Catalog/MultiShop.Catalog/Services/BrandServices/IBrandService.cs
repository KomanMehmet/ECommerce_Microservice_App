using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();

        Task CraeteBrandAsync(CreateBrandDto createBrandDto);

        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);

        Task DeleteBrandAsync(string id);

        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
    }
}
