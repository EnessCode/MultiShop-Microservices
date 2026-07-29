using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
	public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
	{
		private readonly IRepository<Address> _repository;

		public GetAddressByIdQueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetAddressByIdQueryResult
			{
				Id = values.Id,
				UserId = values.UserId,
				Name = values.Name,
				Surname = values.Surname,
				Email = values.Email,
				Phone = values.Phone,
				City = values.City,
				District = values.District,
				Detail = values.Detail,
				OrderNote = values.OrderNote
			};
		}
	}
}