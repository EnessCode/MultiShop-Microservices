using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Dtos.CommentDtos;
using MultiShop.Comment.Services.CommentServices;

namespace MultiShop.Comment.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentService _commentService;

		public CommentsController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCommentList()
		{
			var values = await _commentService.GetAllCommentAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCommentById(int id)
		{
			var value = await _commentService.GetByIdCommentAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment(CreateUserCommentDto createUserCommentDto)
		{
			await _commentService.CreateCommentAsync(createUserCommentDto);
			return Ok("Yorum başarıyla eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateComment(UpdateUserCommentDto updateUserCommentDto)
		{
			await _commentService.UpdateCommentAsync(updateUserCommentDto);
			return Ok("Yorum başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteComment(int id)
		{
			await _commentService.DeleteCommentAsync(id);
			return Ok("Yorum başarıyla silindi");
		}

		[HttpGet("product/{productId}")]
		public async Task<IActionResult> GetCommentsByProductId(string productId)
		{
			var value = await _commentService.GetCommentsByProductIdAsync(productId);
			return Ok(value);
		}
	}
}
