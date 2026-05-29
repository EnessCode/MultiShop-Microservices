using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
	public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
	{
		private readonly IRepository<OrderDetail> _repository;

		public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			values.ProductId = request.ProductId;
			values.ProductName = request.ProductName;
			values.ProductPrice = request.ProductPrice;
			values.ProductAmount = request.ProductAmount;
			values.TotalPrice = request.TotalPrice;
			values.OrderingId = request.OrderingId;

			await _repository.UpdateAsync(values);
		}
	}
}