using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.MainLayoutViewComponents
{
	public class NavbarViewComponent : ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public NavbarViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _categoryService.GetAllCategoriesAsync();
			return View(values);
		}
	}
}
