using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos.UserMessageDtos;
using MultiShop.Message.MessageServices;

namespace MultiShop.Message.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserMessageController : ControllerBase
	{
		private readonly IUserMessageService _userMessageService;

		public UserMessageController(IUserMessageService userMessageService)
		{
			_userMessageService = userMessageService;
		}

		[HttpGet]
		public async Task<IActionResult> UserMessageList()
		{
			var values = await _userMessageService.GetAllUserMessagesAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserMessageById(int id)
		{
			var value = await _userMessageService.GetUserMessageByIdAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateUserMessage(CreateUserMessageDto createUserMessageDto)
		{
			await _userMessageService.CreateUserMessageAsync(createUserMessageDto);
			return Ok("Mesaj başarıyla gönderildi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateUserMessage(UpdateUserMessageDto updateUserMessageDto)
		{
			await _userMessageService.UpdateUserMessageAsync(updateUserMessageDto);
			return Ok("Mesaj başarıyla güncellendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserMessage(int id)
		{
			await _userMessageService.DeleteUserMessageAsync(id);
			return Ok("Mesaj başarıyla silindi.");
		}

		[HttpGet("GetInboxMessages/{id}")]
		public async Task<IActionResult> GetInboxMessages(string id)
		{
			var values = await _userMessageService.GetInboxMessagesAsync(id);
			return Ok(values);
		}

		[HttpGet("GetSendboxMessages/{id}")]
		public async Task<IActionResult> GetSendboxMessages(string id)
		{
			var values = await _userMessageService.GetSendboxMessagesAsync(id);
			return Ok(values);
		}
	}
}
