using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.SpacialOfferServices
{
    public class SpecialOfferService : CatalogCrudService<ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto>, ISpecialOfferService
    {
        public SpecialOfferService(HttpClient httpClient) : base(httpClient, "specialoffers")
        {
        }
    }
}
