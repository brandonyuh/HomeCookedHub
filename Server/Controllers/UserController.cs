using HomeCookedHub.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;

namespace HomeCookedHub.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly DataContext _context;

		public UserController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetUser()
		{
			var users = await _context.Users.ToListAsync();
			return Ok(users);
		}

		[HttpGet("{email}")]
		public async Task<IActionResult> GetUser(String email)
		{
			int id;
			var user = new User();
			if (int.TryParse(email, out id))
			{
				user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
				return Ok(user);
			}
			user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateUser(User user)
		{
			Console.WriteLine(user.Email);
			var dbUser = await _context.Users.FirstOrDefaultAsync(User => User.Id == user.Id);
			dbUser.ProfilePicture = user.ProfilePicture;
			dbUser.Name = user.Name;
			await _context.SaveChangesAsync();
			return Ok();

		}
	}
}
