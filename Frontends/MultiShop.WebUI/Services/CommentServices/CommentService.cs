using MultiShop.DtoLayer.Dtos.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
	public class CommentService : ICommentService
	{
		private readonly HttpClient _httpClient;

		public CommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
		{
			await _httpClient.PostAsJsonAsync("comments", createCommentDto);
		}

		public async Task DeleteCommentAsync(int id)
		{
			await _httpClient.DeleteAsync("comments/" + id);
		}

		public async Task<List<ResultCommentDto>> GetAllCommentAsync()
		{
			var responseMessage = await _httpClient.GetAsync("comments");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
			return values;
		}

		public async Task<UpdateCommentDto> GetByIdCommentAsync(int id)
		{
			var responseMessage = await _httpClient.GetAsync("comments/" + id);
			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
			return value;
		}

		public async Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string productId)
		{
			var responseMessage = await _httpClient.GetAsync("comments/product/" + productId);
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
			return values;
		}

		public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
		{
			await _httpClient.PutAsJsonAsync("comments", updateCommentDto);
		}
	}
}
