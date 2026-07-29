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

			values.UserId = request.UserId;
			values.Name = request.Name;
			values.Surname = request.Surname;
			values.Email = request.Email;
			values.Phone = request.Phone;
			values.City = request.City;
			values.District = request.District;
			values.Detail = request.Detail;
			values.OrderNote = request.OrderNote;

			await _repository.UpdateAsync(values);
		}
	}
}