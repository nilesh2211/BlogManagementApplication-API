
using Microsoft.AspNetCore.Mvc.Filters;

namespace BMA.Infrastructure.Helpers
{
	public class LogUserActivity : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var resultContext = await next();
			if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

			// TODO // Here we can save user activity
		}
	}
}
