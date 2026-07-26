using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
	public class FeatureProductsViewComponent : ViewComponent
	{
		private readonly IProductService _productService;
		private readonly ICommentService _commentService;

		public FeatureProductsViewComponent(IProductService productService, ICommentService commentService)
		{
			_productService = productService;
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _productService.GetAllProductsAsync();

			if (values != null)
			{
				var ratings = new Dictionary<string, double>();

				foreach (var product in values)
				{
					var comments = await _commentService.GetCommentsByProductIdAsync(product.Id);
					ratings[product.Id] = comments != null && comments.Any() ? comments.Average(x => x.Rating) : 0;
				}

				ViewBag.Ratings = ratings;
				return View(values);
			}

			return View(new List<ResultProductDto>());
		}
	}
}
