using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var value = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressID);

            value.UserID = updateAddressCommand.UserID;
            value.City = updateAddressCommand.City;
            value.District = updateAddressCommand.District;
            value.Detail1 = updateAddressCommand.Detail1;
            value.Detail2 = updateAddressCommand.Detail2;
            value.Country = updateAddressCommand.Country;
            value.Email = updateAddressCommand.Email;
            value.Name = updateAddressCommand.Name;
            value.Surname = updateAddressCommand.Surname;
            value.Phone = updateAddressCommand.Phone;
            value.ZipCode = updateAddressCommand.ZipCode;

            await _addressRepository.UpdateAsync(value);
        }
    }
}
