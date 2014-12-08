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
		public ActionResult Send([ModelBinder(typeof(MailModelBinder))]MailModel model, bool isResend)
		{
			var username = ConfigurationManager.AppSettings["SendGridUsername"];
			var password = ConfigurationManager.AppSettings["SendGridPassword"];

			SendGridMessage message = new SendGridMessage();
			message.AddTo(model.To);
			if(isResend)
			{
				message.AddTo(ConfigurationManager.AppSettings["SupportToEmail"]);
			}
			message.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
			message.Subject = model.Subject;
			message.Text = model.MailBody;

			var credentials = new NetworkCredential(username, password);
			var transportWeb = new Web(credentials);
			transportWeb.Deliver(message);

			return Json(new { }, JsonRequestBehavior.DenyGet);
		}
	}
}