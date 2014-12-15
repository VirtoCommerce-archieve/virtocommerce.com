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
	[RoutePrefix("mail")]
	public class MailController : Controller
	{
		// GET: Mail
		//[ValidateAntiForgeryToken]
		[Route("send")]
		public ActionResult Send([ModelBinder(typeof(MailModelBinder))]MailModel model, bool isResend, string redirectUrl)
		{
			var username = ConfigurationManager.AppSettings["SendGridUsername"];
			var password = ConfigurationManager.AppSettings["SendGridPassword"];

			SendGridMessage message = new SendGridMessage();

			message.AddTo(ConfigurationManager.AppSettings["SupportToEmail"]);
			message.From = new MailAddress(model.To, model.FullName);
			message.Subject = model.Subject;
			message.Html = model.FullMailBody;

			var credentials = new NetworkCredential(username, password);
			var transportWeb = new Web(credentials);
			transportWeb.Deliver(message);

			/*
			if (isResend)
			{
				message = new SendGridMessage();
				message.AddTo(model.To);
				message.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
				message.Subject = model.Subject;

				if (string.IsNullOrEmpty(model.MailBody))
					message.Html = "Thank you";
				else
					message.Html = model.MailBody;

				transportWeb.Deliver(message);
			}
			 * */

			return Json(new { IsSuccess = true, RedirectUrl = redirectUrl }, JsonRequestBehavior.DenyGet);
		}
	}
}