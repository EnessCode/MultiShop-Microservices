using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
	public class ProductDetailReviewViewComponent : ViewComponent
	{
		private readonly ICommentService _commentService;

		public ProductDetailReviewViewComponent(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			ViewBag.ProductId = productId;
			var values = await _commentService.GetCommentsByProductIdAsync(productId);
			return View(values);
		}
	}
}
