using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
		{
			await _commentService.CreateCommentAsync(createCommentDto);
			return RedirectToAction("ProductDetail", "ProductList", new { id = createCommentDto.ProductId });
		}
	}
}