using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _orderingRepository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _orderingRepository.GetByIdAsync(request.OrderingID);

            value.OrderDate = request.OrderDate;
            value.UserID = request.UserID;
            value.TotalPrice = request.TotalPrice;

            await _orderingRepository.UpdateAsync(value);
        }
    }
}
