using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AddressDtos;
using MultiShop.WebUI.Services.CatalogServices.AddressServices;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ContactViewComponents
{
	public class ContactAddressViewComponent : ViewComponent
	{
		private readonly IAddressService _addressService;

		public ContactAddressViewComponent(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _addressService.GetAllAddressesAsync();

			if (values != null && values.Any())
			{
				return View(values.FirstOrDefault());
			}

			return View(new ResultAddressDto());
		}
	}
}