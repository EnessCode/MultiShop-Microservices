using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccess.Entities;

namespace MultiShop.Message.DataAccess.Context
{
	public class MessageContext : DbContext
	{
		public MessageContext(DbContextOptions<MessageContext> options) : base(options)
		{

		}
		public DbSet<UserMessage> UserMessages { get; set; }
	}
}
