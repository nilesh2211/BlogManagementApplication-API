
using AutoMapper;
using BMA.Contract.Common;
using BMA.Contract.DTOs.Blog;
using BMA.Domain.Common.Params;
using BMA.Domain.Entities;
using BMA.Domain.Repositories;

namespace BMA.Application.Services
{
	public class BlogService : BaseService, IBlogService
	{
		private readonly IBlogRepository _blogRepository;
		public BlogService(IMapper mapper, IBlogRepository blogRepository) : base(mapper)
		{
			_blogRepository = blogRepository;
		}

		public async Task<ServiceResult> CreateBlogAsync(BlogCreateDto createDto)
		{
			if (string.IsNullOrEmpty(createDto.Title))
				return ServiceResult.Fail(msg: "Title cannot be empty.");

			var blog = _mapper.Map<Blog>(createDto);

			await _blogRepository.CreateBlogAsync(blog);

			return ServiceResult.Success(msg: $"Blog Id:{blog.Id}");
		}

		public async Task<ServiceResult<BlogDisplayDto>> GetByIdAsync(int id)
		{
			Blog blog = await _blogRepository.GetBlogByIdAsync(id);

			var obj = _mapper.Map<BlogDisplayDto>(blog);
			if (obj is null)
			{
				return ServiceResult.Fail<BlogDisplayDto>(msg: "NotFound");
			}
			return ServiceResult.Success(obj);
		}

		public async Task<IEnumerable<BlogDisplayDto>> GetBlogsAsync(BlogParams query)
		{
			IEnumerable<Blog> blogs = await _blogRepository.GetBlogsAsync(query.Limit, query.Offset, query.SearchValue);

			return _mapper.Map<IEnumerable<BlogDisplayDto>>(blogs);
		}

		public async Task<ServiceResult> UpdateBlogAsync(BlogUpdateDto updateDto)
		{
			Blog blog = new();
			blog.Id = updateDto.Id;
			blog.Title = updateDto.Title;
			blog.Desc = updateDto.Desc;

			await _blogRepository.UpdateBlogAsync(blog);
			return ServiceResult.Success();
		}

		public async Task<ServiceResult> DeleteBlogAsync(int id)
		{
			await _blogRepository.DeleteBlogAsync(id);
			return ServiceResult.Success(msg: $"Removed Blog Id: {id}");
		}
	}
}
