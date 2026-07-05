using MultiShop.Comment.Dtos.CommentDtos;

namespace MultiShop.Comment.Services.CommentServices
{
	public interface ICommentService
	{
		Task<List<ResultUserCommentDto>> GetAllCommentAsync();
		Task<GetCommentByIdDto> GetByIdCommentAsync(int id);
		Task CreateCommentAsync(CreateUserCommentDto createCommentDto);
		Task UpdateCommentAsync(UpdateUserCommentDto updateCommentDto);
		Task DeleteCommentAsync(int id); 
		Task<List<GetCommentByIdDto>> GetCommentsByProductIdAsync(string productId);
	}
}