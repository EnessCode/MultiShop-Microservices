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
	public class CargoDetailManager : GenericManager<CargoDetail>, ICargoDetailService
	{
		private readonly ICargoDetailRepository _cargoDetailRepository;

		public CargoDetailManager(IGenericRepository<CargoDetail> genericRepository, ICargoDetailRepository cargoDetailRepository) : base(genericRepository)
		{
			_cargoDetailRepository = cargoDetailRepository;
		}
	}
}