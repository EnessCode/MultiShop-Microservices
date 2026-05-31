using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderDetailsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			var values = await _mediator.Send(new GetOrderDetailQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderDetailById(int id)
		{
			var values = await _mediator.Send(new GetOrderDetailByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş detayı başarıyla eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş detayı başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrderDetail(int id)
		{
			await _mediator.Send(new RemoveOrderDetailCommand(id));
			return Ok("Sipariş detayı başarıyla silindi");
		}
	}
}