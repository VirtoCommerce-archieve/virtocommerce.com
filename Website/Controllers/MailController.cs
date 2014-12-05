using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace VirtoCommerce.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
			var smtp = new SmtpClient();
			smtp.Send("evgokhrimenko@gmail.com", "support@kristalsoft.freshdesk.com", "Тикет", "Тикет");

			return Json(new { }, JsonRequestBehavior.DenyGet);
        }
    }
}