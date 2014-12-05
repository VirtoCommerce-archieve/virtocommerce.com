using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketplaceWeb.Controllers
{
	using System.Net.Mail;
	using System.Web.Mvc;

	[RoutePrefix("")]
	public class PageController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[Route("{pagename}")]
		public ActionResult DisplayPage(string pageName)
		{
			pageName = pageName.Replace("-", string.Empty);
			return View(pageName);
		}
	}
}