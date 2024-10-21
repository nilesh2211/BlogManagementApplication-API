using AutoMapper;
using BMA.Application.Services;
using BMA.Contract.DTOs.Account;
using BMA.Infrastructure.Authentications;
using Microsoft.AspNetCore.Mvc;

namespace BMA.Api.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly IAccountService _accountService;
		public readonly ITokenService _tokenService;
		public AccountController(IAccountService accountService, ITokenService tokenService, IMapper mapper)
		{
			_accountService = accountService;
			_tokenService = tokenService;
		}

		[HttpPost("account/login")]
		public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
		{
			var result = await _accountService.LoginAccountAsync(loginDto);
			if (!result.IsSuccess)
				return BadRequest(result.Message);
			if (result.Value == null) return Unauthorized("Invalid Username or password");

			return new AccountDto
			{
				Name = result.Value.Name,
				Username = result.Value.Username,
				Email = result.Value.Email,
				Token = await _tokenService.CreateToken(result.Value),
				Role = "Admin" // TODO Set Role
			};
		}

		[HttpGet("account/logout")]
		public async Task<IActionResult> Logout()
		{
			// TODO // Logout process
			return Ok();
		}

	}
}