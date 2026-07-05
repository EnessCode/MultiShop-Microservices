using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos.CommentDtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Services.CommentServices
{
	public class CommentService : ICommentService
	{
		private readonly CommentContext _context;

		public CommentService(CommentContext context)
		{
			_context = context;
		}

		public async Task CreateCommentAsync(CreateUserCommentDto createCommentDto)
		{
			var value = new UserComment
			{
				Content = createCommentDto.Content,
				Email = createCommentDto.Email,
				NameSurname = createCommentDto.NameSurname,
				ProductId = createCommentDto.ProductId,
				Rating = createCommentDto.Rating,
				CreatedDate = DateTime.Now,
				Status = true
			};
			await _context.UserComments.AddAsync(value);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCommentAsync(int id)
		{
			var value = await _context.UserComments.FindAsync(id);
			if (value != null)
			{
				_context.UserComments.Remove(value);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<ResultUserCommentDto>> GetAllCommentAsync()
		{
			var values = await _context.UserComments.ToListAsync();
			return values.Select(x => new ResultUserCommentDto
			{
				Id = x.Id,
				Content = x.Content,
				CreatedDate = x.CreatedDate,
				Email = x.Email,
				ImageUrl = x.ImageUrl,
				NameSurname = x.NameSurname,
				ProductId = x.ProductId,
				Rating = x.Rating,
				Status = x.Status
			}).ToList();
		}

		public async Task<GetCommentByIdDto> GetByIdCommentAsync(int id)
		{
			var value = await _context.UserComments.FindAsync(id);
			return new GetCommentByIdDto
			{
				Id = value.Id,
				Content = value.Content,
				CreatedDate = value.CreatedDate,
				Email = value.Email,
				ImageUrl = value.ImageUrl,
				NameSurname = value.NameSurname,
				ProductId = value.ProductId,
				Rating = value.Rating,
				Status = value.Status
			};
		}

		public async Task UpdateCommentAsync(UpdateUserCommentDto updateCommentDto)
		{
			var value = await _context.UserComments.FindAsync(updateCommentDto.Id);
			if (value != null)
			{
				value.Content = updateCommentDto.Content;
				value.Email = updateCommentDto.Email;
				value.NameSurname = updateCommentDto.NameSurname;
				value.ProductId = updateCommentDto.ProductId;
				value.Rating = updateCommentDto.Rating;
				value.Status = updateCommentDto.Status;

				_context.UserComments.Update(value);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<GetCommentByIdDto>> GetCommentsByProductIdAsync(string productId)
		{
			var values = await _context.UserComments.Where(x => x.ProductId == productId).ToListAsync();

			return values.Select(x => new GetCommentByIdDto
			{
				Id = x.Id,
				Content = x.Content,
				CreatedDate = x.CreatedDate,
				Email = x.Email,
				ImageUrl = x.ImageUrl,
				NameSurname = x.NameSurname,
				ProductId = x.ProductId,
				Rating = x.Rating,
				Status = x.Status
			}).ToList();
		}
	}
}
