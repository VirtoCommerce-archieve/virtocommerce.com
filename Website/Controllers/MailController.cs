using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
			var smtp = new SmtpClient();


			MailAddress from = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
			MailAddress to = new MailAddress(model.To);

			MailMessage message = new MailMessage(from, to);

			message.Subject = model.Subject;
			message.Body = model.MailBody;

			//smtp.Send(from, to, subject, mailbody);

			if(isResend)
			{
				from = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
				to = new MailAddress(ConfigurationManager.AppSettings["SupportToEmail"]);

				message = new MailMessage(from, to);

				message.Subject = model.Subject;
				message.Body = model.MailBody;

				//smtp.Send(from, to, subject, mailbody);
			}

			return Json(new { }, JsonRequestBehavior.DenyGet);
		}
	}
}