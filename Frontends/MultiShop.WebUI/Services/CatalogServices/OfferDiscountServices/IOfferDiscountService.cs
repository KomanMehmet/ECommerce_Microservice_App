using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService : ICatalogCrudService<ResultOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto>
    {
    }
}
