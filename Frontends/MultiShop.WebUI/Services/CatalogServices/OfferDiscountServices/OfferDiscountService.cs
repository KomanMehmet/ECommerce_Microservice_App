using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : CatalogCrudService<ResultOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto>, IOfferDiscountService
    {
        public OfferDiscountService(HttpClient httpClient) : base(httpClient, "offerdiscounts")
        {
        }
    }
}
