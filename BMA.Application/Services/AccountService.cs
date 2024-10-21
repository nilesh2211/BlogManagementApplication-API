

using AutoMapper;
using BMA.Contract.Common;
using BMA.Contract.DTOs.Account;
using BMA.Domain.Entities;
using BMA.Domain.Repositories;

namespace BMA.Application.Services
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly IAccountRepository _accountRepository;
		public AccountService(IMapper mapper, IAccountRepository accountRepository) : base(mapper)
		{
			_accountRepository = accountRepository;
		}

		public async Task<ServiceResult<AccountDto>> LoginAccountAsync(LoginDto obj)
		{
			User user = await _accountRepository.LoginAccountAsync(obj.UserName, obj.Password);

			var accountDto = _mapper.Map<AccountDto>(user);

			return ServiceResult.Success(accountDto);
		}
	}
}
