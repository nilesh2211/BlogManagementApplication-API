
using BMA.Application.Services;
using BMA.Domain.Repositories;
using BMA.Infrastructure.Authentications;
using BMA.Infrastructure.Helpers;
using BMA.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BMA.Infrastructure.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{

			// Repository Layer DI
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IBlogRepository, BlogRepository>();

			// Application Service Layer DI
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IBlogService, BlogService>();

			services.AddScoped<LogUserActivity>();

			return services;
		}

	}
}
