using BMA.Contract.DTOs.Account;
using BMA.Domain.Entities;

namespace BMA.Infrastructure.Authentications
{
	public interface ITokenService
	{
		Task<string> CreateToken(AccountDto user);
	}
}
