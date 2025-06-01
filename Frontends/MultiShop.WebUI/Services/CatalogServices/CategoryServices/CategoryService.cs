using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : CatalogCrudService<ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryService
    {
        public CategoryService(HttpClient httpClient) : base(httpClient, "categories")
        {
        }
    }
}
