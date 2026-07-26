using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductDetailController : Controller
	{
		private readonly IProductDetailService _productDetailService;

		public ProductDetailController(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Ürün Detayı", string moduleUrl = "/Admin/ProductDetail/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProductDetail(string id)
		{
			SetBreadcrumb("Ürün Detayı Güncelle");
			var value = await _productDetailService.GetProductDetailByProductIdAsync(id);
			if (value != null)
			{
				return View(value);
			}
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
		{
			await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
			return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
		}
	}
}
