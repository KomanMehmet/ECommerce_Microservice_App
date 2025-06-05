namespace MultiShop.WebUI.Services.OrderServices.GenericServices
{
    public interface IOrderCrudService<TDto, TCreateDto, TUpdateDto>
    {
        Task<List<TDto>> GetAllAsync();

        Task<TUpdateDto> GetByIdAsync(string id);

        Task CreateAsync(TCreateDto createDto);

        Task UpdateAsync(TUpdateDto updateDto);

        Task DeleteAsync(string id);
    }
}
