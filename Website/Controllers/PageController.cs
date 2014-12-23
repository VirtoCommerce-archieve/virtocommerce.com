using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketplaceWeb.Controllers
{
	using System.Net.Mail;
	using System.Web.Hosting;
	using System.Web.Mvc;

	using VirtoCommerce.Publishing;
	using VirtoCommerce.Publishing.Engines;

	//[RoutePrefix("")]
	public class PageController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		//[Route("{pagename}")]
		public ActionResult DisplayPage(string pageName)
		{
			SetMeta();
			var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
			telemetry.TrackTrace("page request");

			if (String.IsNullOrEmpty(pageName))
			{
				pageName = "Index";
			}

			// Check if physical page exists and use standard one, if not use content service
			var viewName = pageName.Replace("-", string.Empty);
			var result = ViewEngines.Engines.FindView(this.ControllerContext, viewName, null);
			if (result == null || result.View == null)
			{
				var filesPath = HostingEnvironment.MapPath("~/App_Data/vc-contents");
				var service = new ContentPublishingService(filesPath, new[] { new LiquidTemplateEngine(filesPath) });

				var item = service.GetContentItem(pageName.Contains("/") ? pageName : String.Format("/pages/{0}", pageName));
				if (item != null)
					return this.View(item.Layout, item);
			}

			return View(viewName);
		}

		private void SetMeta()
		{
			ViewBag.Author = "Virto Commerce";
			ViewBag.Description = "VirtoCommerce offers an enterprise level ecommerce framework designed to expand sales with simple and exciting ecommerce solutions.";
			ViewBag.Keywords = "Virto Commerce, Enterprise eCommerce, ASP.NET eCommerce, Azure eCommerce, Cloud eCommerce, MVC eCommerce, .net shopping cart";
			ViewBag.ItemPropName = "Virto Commerce";
			ViewBag.ItemPropDescription = "Multi Channel Ecommerce Platform | Enterprise Shopping Cart Software | VirtoCommerce";
			ViewBag.ItemPropImage = "/Content/images/virtocommerce.png";
		}
	}
}