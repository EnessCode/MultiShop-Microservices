using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Application.Interfaces.Services
{
	public interface IGenericService<T> where T : class
	{
		Task TInsertAsync(T entity);
		void TUpdate(T entity);
		void TDelete(int id);
		Task<T> TGetByIdAsync(int id);
		Task<List<T>> TGetAllAsync();
	}
}