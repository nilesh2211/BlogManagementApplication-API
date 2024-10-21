
using BMA.Domain.Entities;

namespace BMA.Domain.Repositories
{
	public interface IBlogRepository : IRepository<Blog>
	{
		Task<IEnumerable<Blog>> GetBlogsAsync(int limit, int offset, string searchValue);
		Task<Blog> GetBlogByIdAsync(int id);
		Task CreateBlogAsync(Blog obj);
		Task UpdateBlogAsync(Blog obj);
		Task DeleteBlogAsync(int id);
	}
}
