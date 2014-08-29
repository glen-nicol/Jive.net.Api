using System;
using System.Linq;

namespace Jive.Linq.DAL
{
	public class RestRepo<T> : IRepository<T>
	{
		private IHttpRequester _requester;

		public RestRepo(IHttpRequester requester)
		{
			if (requester == null)
			{
				throw new ArgumentNullException("requester");
			}
			_requester = requester;
		}

		public void Add(T entity)
		{
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public T GetById(long id)
		{
			throw new NotImplementedException();
		}
	}
}
