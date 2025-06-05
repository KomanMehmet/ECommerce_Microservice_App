using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var values = await _addressRepository.GetByIdAsync(getAddressByIdQuery.Id);

            return new GetAddressByIdQueryResult
            {
                AddressID = values.AddressID,
                UserID = values.UserID,
                District = values.District,
                City = values.City,
                Detail1 = values.Detail1,
                Detail2 = values.Detail2,
                Country = values.Country,
                ZipCode = values.ZipCode,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Phone = values.Phone
            };
        }
    }
}
