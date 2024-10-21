
namespace BMA.Contract.DTOs.Blog
{
	public class BlogDisplayDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Desc { get; set; } = string.Empty;
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
	}
}
