using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService : ICatalogCrudService<ResultContactDto, CreateContactDto, UpdateContactDto>
    {
    }
}
