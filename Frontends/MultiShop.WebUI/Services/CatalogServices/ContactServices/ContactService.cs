using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : CatalogCrudService<ResultContactDto, CreateContactDto, UpdateContactDto>, IContactService
    {
        public ContactService(HttpClient httpClient) : base(httpClient, "contacts")
        {
        }
    }
}
