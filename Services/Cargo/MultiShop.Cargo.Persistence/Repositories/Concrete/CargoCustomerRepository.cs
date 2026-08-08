using MultiShop.Cargo.Application.Interfaces.Repositories;
using MultiShop.Cargo.Domain.Entities;
using MultiShop.Cargo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Persistence.Repositories.Concrete
{
	public class CargoCustomerRepository : GenericRepository<CargoCustomer>, ICargoCustomerRepository
	{
		private readonly CargoContext _context;

		public CargoCustomerRepository(CargoContext context) : base(context)
		{
			_context = context;
		}

		public CargoCustomer GetByUserCargoCustomerId(string id)
		{
			return _context.CargoCustomers.FirstOrDefault(x => x.UserCustomerId == id);
		}
	}
}