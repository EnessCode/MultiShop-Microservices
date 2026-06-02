using MultiShop.Cargo.Application.Interfaces.Repositories;
using MultiShop.Cargo.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Application.Services.Concrete
{
	public class GenericManager<T> : IGenericService<T> where T : class
	{
		private readonly IGenericRepository<T> _genericRepository;

		public GenericManager(IGenericRepository<T> genericRepository)
		{
			_genericRepository = genericRepository;
		}

		public async Task TInsertAsync(T entity)
		{
			await _genericRepository.InsertAsync(entity);
		}

		public void TUpdate(T entity)
		{
			_genericRepository.Update(entity);
		}

		public void TDelete(int id)
		{
			_genericRepository.Delete(id);
		}

		public async Task<T> TGetByIdAsync(int id)
		{
			return await _genericRepository.GetByIdAsync(id);
		}

		public async Task<List<T>> TGetAllAsync()
		{
			return await _genericRepository.GetAllAsync();
		}
	}
}