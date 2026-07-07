using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AddressDtos; 
using MultiShop.Catalog.Services.AddressServices; 

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly IAddressService _addressService;

		public AddressesController(IAddressService addressService)
		{
			_addressService = addressService;
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			var values = await _addressService.GetAllAddressesAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddressById(string id)
		{
			var value = await _addressService.GetAddressByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
		{
			await _addressService.CreateAddressAsync(createAddressDto);
			return Ok("Adres bilgisi başarıyla eklendi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
		{
			await _addressService.UpdateAddressAsync(updateAddressDto);
			return Ok("Adres bilgisi başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAddress(string id)
		{
			await _addressService.DeleteAddressAsync(id);
			return Ok("Adres bilgisi başarıyla silindi.");
		}
	}
}