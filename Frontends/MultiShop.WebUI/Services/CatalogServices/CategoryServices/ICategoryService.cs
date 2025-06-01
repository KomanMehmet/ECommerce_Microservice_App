using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService : ICatalogCrudService<ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}
