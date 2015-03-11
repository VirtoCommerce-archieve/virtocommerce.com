using System;
using System.Collections.Generic;
using System.Configuration;
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

			routes.MapMvcAttributeRoutes();

			var virtoCommerceIgnoreRoutes = ConfigurationManager.AppSettings["VirtoCommerceIgnoreRoutes"];

			if (virtoCommerceIgnoreRoutes != null)
			{
				foreach (var route in virtoCommerceIgnoreRoutes.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					routes.IgnoreRoute(route);
				}
			}

			routes.MapRoute(
				name: "Default",
				url: "{*pageName}",
				defaults: new { controller = "Page", action = "DisplayPage" }
			);
		}
	}
}
