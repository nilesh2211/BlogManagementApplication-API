
using BMA.Contract.Common;
using BMA.Contract.DTOs.Account;

namespace BMA.Application.Services
{
	public interface IAccountService
	{
		Task<ServiceResult<AccountDto>> LoginAccountAsync(LoginDto loginDto);
	}
}
