using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.SpacialOfferServices
{
    public interface ISpecialOfferService : ICatalogCrudService<ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto>
    {
    }
}
