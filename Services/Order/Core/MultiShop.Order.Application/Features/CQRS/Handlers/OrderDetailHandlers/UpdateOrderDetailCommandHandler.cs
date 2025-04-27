using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var value = await _orderDetailRepository.GetByIdAsync(updateOrderDetailCommand.OrderDetailID);

            value.ProductName = updateOrderDetailCommand.ProductName;
            value.ProductPrice = updateOrderDetailCommand.ProductPrice;
            value.ProductAmount = updateOrderDetailCommand.ProductAmount;
            value.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            value.ProductID = updateOrderDetailCommand.ProductID;
            value.OrderingId = updateOrderDetailCommand.OrderingId;

            await _orderDetailRepository.UpdateAsync(value);
        }
    }
}
