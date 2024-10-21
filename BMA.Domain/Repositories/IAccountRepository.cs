
using BMA.Domain.Entities;

namespace BMA.Domain.Repositories
{
	public interface IAccountRepository : IRepository<User>
	{
		Task<User> LoginAccountAsync(string userName, string password);
	}
}
