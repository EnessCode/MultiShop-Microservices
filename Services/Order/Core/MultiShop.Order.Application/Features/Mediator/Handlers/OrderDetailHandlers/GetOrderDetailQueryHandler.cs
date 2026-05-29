using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderDetailQueryResult
			{
				Id = x.Id,
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				ProductPrice = x.ProductPrice,
				ProductAmount = x.ProductAmount,
				TotalPrice = x.TotalPrice,
				OrderingId = x.OrderingId
			}).ToList();
		}
	}
}