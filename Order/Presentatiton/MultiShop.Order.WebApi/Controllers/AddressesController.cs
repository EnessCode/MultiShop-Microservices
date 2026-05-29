using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using System.Threading.Tasks;

namespace MultiShop.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AddressesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			var values = await _mediator.Send(new GetAddressQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddressById(int id)
		{
			var values = await _mediator.Send(new GetAddressByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Adres bilgisi başarıyla eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok("Adres bilgisi başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAddress(int id)
		{
			await _mediator.Send(new RemoveAddressCommand(id));
			return Ok("Adres bilgisi başarıyla silindi");
		}
	}
}