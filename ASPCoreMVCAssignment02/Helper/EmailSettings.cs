using DAL.Entities;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Assignment02.Helper
{
	public static class EmailSettings 
	{
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);

			client.EnableSsl = true;
			client.Credentials = new NetworkCredential("mahmoudaraby847@gmail.com", "sflexbiisfhcuqpy");

			client.Send("mahmoudaraby847@gmail.com", email.To, email.Title, email.Body);

	    }
	}
}
