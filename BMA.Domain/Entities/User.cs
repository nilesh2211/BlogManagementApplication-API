﻿using BMA.Domain.Common;

namespace BMA.Domain.Entities
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string? Password { get; set; }
	}
}
