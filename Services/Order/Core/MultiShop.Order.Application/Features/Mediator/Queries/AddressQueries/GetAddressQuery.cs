using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries
{
	public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
	{
	}
}