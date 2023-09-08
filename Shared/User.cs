using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeCookedHub.Shared
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string? ProfilePicture { get; set; }
		public string? UserBio { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string Role { get; set; } = "User";

	}
}
