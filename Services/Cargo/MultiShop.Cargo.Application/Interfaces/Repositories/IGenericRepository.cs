using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Application.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task InsertAsync(T entity);
		void Update(T entity);
		void Delete(int id);
		Task<T> GetByIdAsync(int id);
		Task<List<T>> GetAllAsync();
	}
}
