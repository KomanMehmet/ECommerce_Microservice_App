using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public CreateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _addressRepository.CreateAsync(new Address
            {
                UserID = createAddressCommand.UserID,
                District = createAddressCommand.District,
                City = createAddressCommand.City,
                Detail1 = createAddressCommand.Detail1,
                Detail2 = createAddressCommand.Detail2,
                Country = createAddressCommand.Country,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Phone = createAddressCommand.Phone,
                ZipCode = createAddressCommand.ZipCode,
            });
        }
    }
}
