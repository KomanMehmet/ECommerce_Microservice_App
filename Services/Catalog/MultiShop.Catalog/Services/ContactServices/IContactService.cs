using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();

        Task CreateContactyAsync(CreateContactDto createContactDto);

        Task UpdateContactyAsync(UpdateContactDto updateContactDto);

        Task DeleteContactAsync(string id);

        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
