

using BMA.Domain.Entities;
using BMA.Domain.Repositories;
using BMA.Infrastructure.Data;
using Newtonsoft.Json;

namespace BMA.Infrastructure.Repositories
{
	public class BlogRepository : Repository<Blog>, IBlogRepository
	{
		public BlogRepository() : base()
		{

		}

		public async Task CreateBlogAsync(Blog obj)
		{
			var readWrite = new JSONReadWrite();
			var blogs = JsonConvert.DeserializeObject<List<Blog>>(readWrite.Read("blog.json", "data"));

			obj.Id = blogs!.Count + 1;
			blogs.Add(obj);

			string jSONString = JsonConvert.SerializeObject(blogs);
			readWrite.Write("blog.json", "data", jSONString);
		}

		public async Task DeleteBlogAsync(int id)
		{
			var readWrite = new JSONReadWrite();
			var blogs = JsonConvert.DeserializeObject<List<Blog>>(readWrite.Read("blog.json", "data"));
			if (blogs!.Count > 0)
			{
				int index = blogs.FindIndex(x => x.Id == id);
				blogs.RemoveAt(index);
				string jSONString = JsonConvert.SerializeObject(blogs);
				readWrite.Write("blog.json", "data", jSONString);
			}
		}

		public async Task<Blog> GetBlogByIdAsync(int id)
		{
			var readWrite = new JSONReadWrite();
			var blogs = JsonConvert.DeserializeObject<List<Blog>>(readWrite.Read("blog.json", "data"));
			if (blogs!.Count > 0)
			{
				return blogs.FirstOrDefault(u => u.Id == id);
			}

			return null;
		}

		public async Task<IEnumerable<Blog>> GetBlogsAsync(int limit, int offset, string searchValue)
		{
			var readWrite = new JSONReadWrite();
			var blogs = JsonConvert.DeserializeObject<List<Blog>>(readWrite.Read("blog.json", "data"));
			if (!string.IsNullOrEmpty(searchValue))
			{
				return blogs.Where(b => b.Title.Contains(searchValue) || b.Desc.Contains(searchValue)).OrderByDescending(p => p.Created)
		.Skip(offset).Take(limit).ToList();
			}

			return blogs.OrderByDescending(p => p.Created)
		.Skip(offset).Take(limit).ToList();
		}

		public async Task UpdateBlogAsync(Blog obj)
		{
			var readWrite = new JSONReadWrite();
			var blogs = JsonConvert.DeserializeObject<List<Blog>>(readWrite.Read("blog.json", "data"));
			int index = blogs.FindIndex(x => x.Id == obj.Id);
			blogs[index] = obj;
			string jSONString = JsonConvert.SerializeObject(blogs);
			readWrite.Write("blog.json", "data", jSONString);
		}
	}
}
