
using BMA.Contract.DTOs.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BMA.Infrastructure.Authentications
{
	public class TokenService : ITokenService
	{
		private readonly SymmetricSecurityKey _key;

		public TokenService(IConfiguration config)
		{
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
		}
		public async Task<string> CreateToken(AccountDto user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
			};

			// TODO //
			//var roles = await _userManager.GetRolesAsync(user);
			//claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));


			var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
