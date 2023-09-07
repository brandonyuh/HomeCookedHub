using HomeCookedHub.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
	}
}
