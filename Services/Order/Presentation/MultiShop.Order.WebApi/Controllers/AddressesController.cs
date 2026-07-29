using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderAddressesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderAddressesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> OrderAddressList()
		{
			var values = await _mediator.Send(new GetAddressQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderAddressById(int id)
		{
			var values = await _mediator.Send(new GetAddressByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrderAddress(CreateAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş adres bilgisi başarıyla eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOrderAddress(UpdateAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş adres bilgisi başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrderAddress(int id)
		{
			await _mediator.Send(new RemoveAddressCommand(id));
			return Ok("Sipariş adres bilgisi başarıyla silindi");
		}
	}
}
