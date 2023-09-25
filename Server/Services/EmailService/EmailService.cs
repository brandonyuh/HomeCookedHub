using MimeKit;

namespace HomeCookedHub.Server.Services.EmailService
{
	public class EmailService : IEmailService
	{
		private readonly IConfiguration _config;

		public EmailService(IConfiguration config)
        {
			_config = config;
		}

		public void SendEmail(Email emailMessage)
		{
			string to = emailMessage.To;
			string subject = emailMessage.Subject;
			string body = emailMessage.Body;

			if (to == null || to.Equals(string.Empty))
			{
				to = _config.GetSection("EmailUserName").Value;
			}
			string from = _config.GetSection("EmailUserName").Value;

			if (subject == null || subject.Equals(string.Empty))
				subject = "Test Email Subject from ethereal";

			if(body == null || body.Equals(string.Empty))
				body = "Test Email Body from ethereal";

			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse(from));
			email.To.Add(MailboxAddress.Parse(to));
			email.Subject = subject;
			email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
			smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
			smtp.Send(email);
			smtp.Disconnect(true);
		}
	}
}
