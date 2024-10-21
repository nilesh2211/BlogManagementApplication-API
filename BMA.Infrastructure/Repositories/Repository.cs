
using BMA.Domain.Repositories;

namespace BMA.Infrastructure.Repositories
{

	// TODO // We can create generic like this but not rquired in test project
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		public Repository()
		{
		}
		public Task Add(TEntity obj)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task Update(TEntity obj)
		{
			throw new NotImplementedException();
		}

		Task<TEntity> IRepository<TEntity>.GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
