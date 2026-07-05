namespace MultiShop.Comment.Dtos.CommentDtos
{
	public class CreateUserCommentDto
	{
		public string NameSurname { get; set; }
		public string? ImageUrl { get; set; }
		public string Email { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; }
		public string ProductId { get; set; }
	}
}
