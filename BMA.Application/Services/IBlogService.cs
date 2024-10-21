using BMA.Contract.Common;
using BMA.Contract.DTOs.Blog;
using BMA.Domain.Common.Params;

namespace BMA.Application.Services
{
	public interface IBlogService
	{
		Task<IEnumerable<BlogDisplayDto>> GetBlogsAsync(BlogParams query);
		Task<ServiceResult<BlogDisplayDto>> GetByIdAsync(int id);
		Task<ServiceResult> CreateBlogAsync(BlogCreateDto createDto);
		Task<ServiceResult> UpdateBlogAsync(BlogUpdateDto updateDto);
		Task<ServiceResult> DeleteBlogAsync(int id);
	}
}
