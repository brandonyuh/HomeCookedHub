using HomeCookedHub.Server.Services.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HomeCookedHub.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;

		public EmailController(IEmailService emailService)
        {
			_emailService = emailService;
		}

        [HttpPost]
		public IActionResult SendEmail(Email request)
		{
			_emailService.SendEmail(request);
			return Ok();
		}
	}
}
