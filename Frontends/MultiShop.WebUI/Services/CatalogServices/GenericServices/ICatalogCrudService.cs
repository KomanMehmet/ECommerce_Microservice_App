namespace MultiShop.WebUI.Services.CatalogServices.GenericServices
{
    public interface ICatalogCrudService<TDto, TCreateDto, TUpdateDto>
    {
        Task<List<TDto>> GetAllAsync();

        Task<TUpdateDto> GetByIdAsync(string id);

        Task CreateAsync(TCreateDto createDto);

        Task UpdateAsync(TUpdateDto updateDto);

        Task DeleteAsync(string id);
    }
}
