using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VirtoCommerce
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			/*
			routes.MapRoute(
				name: "ControllerDefault",
				url: "{controller}/{action}/{id}",
				defaults: new { id = UrlParameter.Optional }
			);
			 * */


			routes.MapMvcAttributeRoutes();

			//routes.MapRoute("NoCmsRoute", "{*pageName}", new { controller = "Page", action = "DisplayPage" });

			//routes.MapRoute(
			//	name: "Mail",
			//	url: "mail/{action}",
			//	defaults: new { controller = "Page", action = "Index" });

			/*
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
			);
			 * */

			routes.MapRoute(
				name: "DefaultFeatures",
				url: "features/{pageName}",
				defaults: new { controller = "Page", action = "DisplayPage" }
			);

			routes.MapRoute(
				name: "DefaultOurOffers",
				url: "our-offers/{*pageName}",
				defaults: new { controller = "Page", action = "DisplayPage" }
			);

			routes.MapRoute(
				name: "DefaultPartners",
				url: "partners/{*pageName}",
				defaults: new { controller = "Page", action = "DisplayPage" }
			);

			routes.MapRoute(
				name: "DefaultTryNow",
				url: "try-now/{pageName}",
				defaults: new { controller = "Page", action = "DisplayPage" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{*pageName}",
				defaults: new { controller = "Page", action = "DisplayPage" }
			);
		}
	}
}
