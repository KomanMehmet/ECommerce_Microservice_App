﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _orderingRepository;

        public GetOrderingQueryHandler(IRepository<Ordering> orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderingRepository.GetAllAsync();

            return values.Select(x => new GetOrderingQueryResult
            {
                OrderingID = x.OrderingID,
                UserID = x.UserID,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate
            }).ToList();
        }
    }
}
