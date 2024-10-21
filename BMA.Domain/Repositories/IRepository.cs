

namespace BMA.Domain.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task Add(TEntity obj);
		Task Update(TEntity obj);
		Task Delete(int id);
		Task<TEntity> GetById(int id);
	}
}
