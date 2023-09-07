using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCookedHub.Shared
{
	public class User
	{
		public required int Id { get; set; }
		public required string Name { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public required string UserType { get; set; }
		public string? ProfilePicture { get; set; }
		public string? UserBio { get; set; }
		
	}
}
