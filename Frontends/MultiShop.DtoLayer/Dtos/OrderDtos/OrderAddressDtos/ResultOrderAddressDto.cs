using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.Dtos.OrderDtos.OrderAddressDtos
{
	public class ResultUserMessageDto
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string Detail { get; set; }
		public string? OrderNote { get; set; }
	}
}
