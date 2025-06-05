using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _addressRepository.GetAllAsync();

            return values.Select(x => new GetAddressQueryResult
            {
                AddressID = x.AddressID,
                UserID = x.UserID,
                City = x.City,
                District = x.District,
                Detail1 = x.Detail1,
                Detail2 = x.Detail2,
                Country = x.Country,
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname,
                Phone = x.Phone,
                ZipCode = x.ZipCode
            }).ToList();
        }
    }
}
