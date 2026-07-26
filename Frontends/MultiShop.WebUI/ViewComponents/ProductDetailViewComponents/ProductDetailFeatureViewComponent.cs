using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductDetailFeatureViewComponent : ViewComponent
	{
		private readonly IProductService _productService;
		private readonly ICommentService _commentService;

		public ProductDetailFeatureViewComponent(IProductService productService, ICommentService commentService)
		{
			_productService = productService;
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			var product = await _productService.GetProductByIdAsync(productId);
			var comments = await _commentService.GetCommentsByProductIdAsync(productId);

			ViewBag.ReviewCount = comments?.Count ?? 0;
			ViewBag.AverageRating = comments != null && comments.Any() ? comments.Average(x => x.Rating) : 0;

			return View(product);
		}
	}
}
