using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.CommentDtos
{
	public class CreateCommentDto
	{
		public string NameSurname { get; set; }
		public string? ImageUrl { get; set; }
		public string Email { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; }
		public string ProductId { get; set; }
	}
}
