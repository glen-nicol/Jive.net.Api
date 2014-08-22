using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jive.net.Api.DAL
{
	public interface IRepository<T>
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		IQueryable<T> GetAll();
		T GetById(long id);
	}
}
