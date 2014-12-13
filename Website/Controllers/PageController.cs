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
			var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
			telemetry.TrackTrace("page request");


            // Check if physical page exists and use standard one, if not use content service
            var viewName = pageName.Replace("-", string.Empty);
            var result = ViewEngines.Engines.FindView(this.ControllerContext, viewName, null);
		    if (result == null || result.View == null)
		    {
                var filesPath = HostingEnvironment.MapPath("~/App_Data/Contents");
                var service = new ContentPublishingService(filesPath, new[] { new LiquidTemplateEngine(filesPath) });

                var item = service.GetContentItem(String.Format("/pages/{0}", pageName));
                if(item != null)
		         return this.View(item.Layout, item);
		    }

		    if (String.IsNullOrEmpty(pageName))
		        viewName = "Index";

            return View(viewName);
		}
	}
}