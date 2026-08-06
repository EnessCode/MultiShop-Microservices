using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccess.Context;
using MultiShop.Message.DataAccess.Entities;
using MultiShop.Message.Dtos.UserMessageDtos;

namespace MultiShop.Message.Services
{
	public class UserMessageService : IUserMessageService
	{
		private readonly MessageContext _context;
		private readonly IMapper _mapper;

		public UserMessageService(MessageContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto)
		{
			var value = _mapper.Map<UserMessage>(createUserMessageDto);
			await _context.UserMessages.AddAsync(value);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteUserMessageAsync(int id)
		{
			var value = await _context.UserMessages.FindAsync(id);
			if (value != null)
			{
				_context.UserMessages.Remove(value);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<ResultUserMessageDto>> GetAllUserMessagesAsync()
		{
			var values = await _context.UserMessages.ToListAsync();
			return _mapper.Map<List<ResultUserMessageDto>>(values);
		}

		public async Task<GetUserMessageByIdDto> GetUserMessageByIdAsync(int id)
		{
			var value = await _context.UserMessages.FindAsync(id);
			return _mapper.Map<GetUserMessageByIdDto>(value);
		}

		public async Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto)
		{
			var value = _mapper.Map<UserMessage>(updateUserMessageDto);
			_context.UserMessages.Update(value);
			await _context.SaveChangesAsync();
		}

		public async Task<List<ResultInboxUserMessageDto>> GetInboxMessagesAsync(string id)
		{
			var values = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
			return _mapper.Map<List<ResultInboxUserMessageDto>>(values);
		}

		public async Task<List<ResultSendboxUserMessageDto>> GetSendboxMessagesAsync(string id)
		{
			var values = await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync();
			return _mapper.Map<List<ResultSendboxUserMessageDto>>(values);
		}
	}
}
