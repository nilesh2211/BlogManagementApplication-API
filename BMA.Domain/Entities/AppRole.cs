namespace BMA.Domain.Entities
{
	public class AppRole 
	{
		public ICollection<AppUserRole> UserRoles { get; set; }
	}
}
