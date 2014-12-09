using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using VirtoCommerce.Binders;
using VirtoCommerce.Models;

namespace VirtoCommerce.Controllers
{
	public class MailController : Controller
	{
		// GET: Mail
		[ValidateAntiForgeryToken]
		public ActionResult Send([ModelBinder(typeof(MailModelBinder))]MailModel model, bool isResend, string redirectUrl)
		{
			var username = ConfigurationManager.AppSettings["SendGridUsername"];
			var password = ConfigurationManager.AppSettings["SendGridPassword"];

			var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
			telemetry.TrackTrace(username);
			telemetry.TrackTrace(password);

			SendGridMessage message = new SendGridMessage();

			message.AddTo(ConfigurationManager.AppSettings["SupportToEmail"]);
			message.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
			message.Subject = model.Subject;
			message.Text = model.FullMailBody;

			var credentials = new NetworkCredential(username, password);
			var transportWeb = new Web(credentials);
			transportWeb.Deliver(message);

			if (isResend)
			{
				message = new SendGridMessage();
				message.AddTo(model.To);
				message.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
				message.Subject = model.Subject;

				if (string.IsNullOrEmpty(model.MailBody))
					message.Text = "Thank you";
				else
					message.Text = model.MailBody;
				transportWeb.Deliver(message);
			}

			return Json(new { IsSuccess = true, RedirectUrl = redirectUrl }, JsonRequestBehavior.DenyGet);
		}
	}
}