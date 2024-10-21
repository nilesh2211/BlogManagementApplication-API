using BMA.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BMA.Api.Controllers
{
	
	[ServiceFilter(typeof(LogUserActivity))]
	[Route("api")]
	[ApiController]
	public class BaseApiController : ControllerBase
	{
	}
	public record ApiResponse<T>(T Data, bool Success = true, string ErrorMessage = null);
}
