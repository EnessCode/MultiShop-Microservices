using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
	public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
	{
		private readonly IRepository<Address> _repository;

		public UpdateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			values.City = request.City;
			values.District = request.District;
			values.Detail = request.Detail;
			values.UserId = request.UserId;

			await _repository.UpdateAsync(values);
		}
	}
}