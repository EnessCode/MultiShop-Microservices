using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		private void SetBreadcrumb(string activePage, string moduleName = "Yorumlar", string moduleUrl = "/Admin/Comment/Index")
		{
			ViewBag.v1 = moduleName;
			ViewBag.v1_url = moduleUrl;
			ViewBag.v2 = activePage;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			SetBreadcrumb("Yorum Listesi");
			var values = await _commentService.GetAllCommentAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> UpdateComment(int id)
		{
			SetBreadcrumb("Yorum Güncelle");
			var value = await _commentService.GetByIdCommentAsync(id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
		{
			await _commentService.UpdateCommentAsync(updateCommentDto);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });


		}

		public async Task<IActionResult> DeleteComment(int id)
		{
			await _commentService.DeleteCommentAsync(id);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}
	}
}
