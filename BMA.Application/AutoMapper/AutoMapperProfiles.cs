
using AutoMapper;
using BMA.Contract.DTOs.Account;
using BMA.Contract.DTOs.Blog;
using BMA.Domain.Entities;

namespace BMA.Application.AutoMapper
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<User, AccountDto>();
			CreateMap<Blog, BlogDisplayDto>();
			CreateMap<BlogUpdateDto, Blog>();
			CreateMap<BlogCreateDto, Blog>();
		}
	}
}
