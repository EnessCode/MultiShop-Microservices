using MultiShop.Cargo.Application.Interfaces.Repositories;
using MultiShop.Cargo.Application.Interfaces.Services;
using MultiShop.Cargo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Application.Services.Concrete
{
	public class CargoCustomerManager : GenericManager<CargoCustomer>, ICargoCustomerService
	{
		private readonly ICargoCustomerRepository _cargoCustomerRepository;

		public CargoCustomerManager(IGenericRepository<CargoCustomer> genericRepository, ICargoCustomerRepository cargoCustomerRepository) : base(genericRepository)
		{
			_cargoCustomerRepository = cargoCustomerRepository;
		}

		public CargoCustomer GetByUserCargoCustomerId(string id)
		{
			return _cargoCustomerRepository.GetByUserCargoCustomerId(id);
		}
	}
}