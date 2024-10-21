

using BMA.Domain.Entities;
using BMA.Domain.Repositories;
using BMA.Infrastructure.Data;
using Newtonsoft.Json;

namespace BMA.Infrastructure.Repositories
{
	public class AccountRepository : Repository<User>, IAccountRepository
	{
		public AccountRepository() : base()
		{

		}
		public async Task<User> LoginAccountAsync(string userName, string password)
		{
			var readWrite = new JSONReadWrite();
			var Users = JsonConvert.DeserializeObject<List<User>>(readWrite.Read("user.json", "data"));
			if (Users!.Count > 0)
			{
				return Users.FirstOrDefault(u => u.Username == userName && u.Password == password);
			}

			return null;
		}
	}
}
