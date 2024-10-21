

using BMA.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BMA.Infrastructure.Extensions
{
	public static class IdentityServiceExtensions
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{
			//services.AddIdentityCore<User>(opt =>
			//{
			//	opt.Password.RequireNonAlphanumeric = false;
			//});
			//	//.AddRoles<AppRole>()
			//	.AddRoleManager<RoleManager<AppRole>>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(opt =>
				{
					opt.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
						ValidateIssuer = false,
						ValidateAudience = false
					};
					opt.Events = new JwtBearerEvents
					{
						OnMessageReceived = context =>
						{
							var accessToken = context.Request.Query["access_token"];
							var path = context.HttpContext.Request.Path;
							if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
							{
								context.Token = accessToken;
							}
							return Task.CompletedTask;
						}
					};
				}

			);


			// TODO // we can add specific policy like that based on requirment 

			//services.AddAuthorization(opt =>
			//{
			//	opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
			//});

			return services;
		}

	}
}
