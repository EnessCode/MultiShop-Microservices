using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
	public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
	{
		public int Id { get; set; }

		public GetOrderDetailByIdQuery(int id)
		{
			Id = id;
		}
	}
}