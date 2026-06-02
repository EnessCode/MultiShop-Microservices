using MultiShop.Cargo.Application.Interfaces.Repositories;
using MultiShop.Cargo.Persistence.Context;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Persistence.Repositories.Concrete
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly CargoContext _context;

		public GenericRepository(CargoContext context)
		{
			_context = context;
		}

		public async Task InsertAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var value = _context.Set<T>().Find(id);
			if (value != null)
			{
				_context.Set<T>().Remove(value);
				_context.SaveChanges();
			}
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}
	}
}