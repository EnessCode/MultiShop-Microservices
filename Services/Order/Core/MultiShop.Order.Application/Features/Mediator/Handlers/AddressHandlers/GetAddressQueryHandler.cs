using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
	public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
	{
		private readonly IRepository<Address> _repository;

		public GetAddressQueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAddressQueryResult
			{
				Id = x.Id,
				UserId = x.UserId,
				Name = x.Name,
				Surname = x.Surname,
				Email = x.Email,
				Phone = x.Phone,
				City = x.City,
				District = x.District,
				Detail = x.Detail,
				OrderNote = x.OrderNote
			}).ToList();
		}
	}
}