
using BMA.Application.Services;
using BMA.Contract.DTOs.Blog;
using BMA.Domain.Common.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMA.Api.Controllers
{
	[Authorize]
	public class BlogsController : BaseApiController
	{
		private readonly IBlogService _blogService;
		public BlogsController(IBlogService blogService)
		{
			_blogService = blogService;
		}

		[HttpGet("blogs")]
		public async Task<ActionResult<IEnumerable<BlogDisplayDto>>> GetBlogs([FromQuery] BlogParams queryParams)
		{
			return Ok(new ApiResponse<IEnumerable<BlogDisplayDto>>(await _blogService.GetBlogsAsync(queryParams)));
		}

		[HttpGet("blog/{id}")]
		public async Task<ActionResult<BlogDisplayDto>> GetBlogById(int id)
		{
			var blogDetails = await _blogService.GetByIdAsync(id);
			return (await _blogService.GetByIdAsync(id)).IsSuccess ?
					Ok(blogDetails.Value) :
					NotFound(blogDetails.Message);
		}

		[HttpPut("blog")]
		public async Task<IActionResult> Put(BlogUpdateDto blogUpdateDto)
		{
			if (blogUpdateDto is null)
				return BadRequest($"Argument null for {nameof(blogUpdateDto)}.");

			if (blogUpdateDto.Id == 0)
				return BadRequest("Id field cannot be empty or 0");

			var result = await _blogService.UpdateBlogAsync(blogUpdateDto);
			if (!result.IsSuccess)
				return BadRequest(result.Message);

			return NoContent();
		}

		[HttpPost("blog")]
		public async Task<IActionResult> Create(BlogCreateDto blogCreateDto)
		{
			if (blogCreateDto is null)
				return BadRequest($"Argument null for {nameof(blogCreateDto)}.");

			var result = await _blogService.CreateBlogAsync(blogCreateDto);
			if (!result.IsSuccess)
				return BadRequest(result.Message);

			return Ok(result.IsSuccess);
		}

		[HttpDelete("blog/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _blogService.DeleteBlogAsync(id);
			if (!result.IsSuccess)
				return BadRequest(result.Message);

			return Ok();
		}

	}
}