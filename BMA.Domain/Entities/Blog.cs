using BMA.Domain.Common;

namespace BMA.Domain.Entities
{
	public class Blog : BaseEntity
	{
		public string Title { get; set; }
		public string Desc { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
	}
}
