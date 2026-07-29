using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
	public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
	{
		private readonly IRepository<Address> _repository;

		public CreateAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Address
			{
				UserId = request.UserId,
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				Phone = request.Phone,
				City = request.City,
				District = request.District,
				Detail = request.Detail,
				OrderNote = request.OrderNote
			});
		}
	}
}