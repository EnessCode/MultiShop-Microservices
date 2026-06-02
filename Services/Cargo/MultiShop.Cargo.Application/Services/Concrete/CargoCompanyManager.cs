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
	public class CargoCompanyManager : GenericManager<CargoCompany>, ICargoCompanyService
	{
		private readonly ICargoCompanyRepository _cargoCompanyRepository;

		public CargoCompanyManager(IGenericRepository<CargoCompany> genericRepository, ICargoCompanyRepository cargoCompanyRepository) : base(genericRepository)
		{
			_cargoCompanyRepository = cargoCompanyRepository;
		}
	}
}