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
	public class CargoOperationManager : GenericManager<CargoOperation>, ICargoOperationService
	{
		private readonly ICargoOperationRepository _cargoOperationRepository;

		public CargoOperationManager(IGenericRepository<CargoOperation> genericRepository, ICargoOperationRepository cargoOperationRepository) : base(genericRepository)
		{
			_cargoOperationRepository = cargoOperationRepository;
		}
	}
}