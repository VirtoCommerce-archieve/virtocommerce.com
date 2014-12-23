using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VirtoCommerce.Binders;
using VirtoCommerce.Controllers;

namespace VirtoCommerce
{
    using System.Web.Http;

    using VirtoCommerce.App_Start;

    public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			ModelBinders.Binders[typeof(MailModelBinder)] = new MailModelBinder();
            GlobalConfiguration.Configure(WebApiConfig.Register);
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			Exception exception = Server.GetLastError();
			Response.Clear();

			var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
			telemetry.TrackTrace("error request");

			HttpException httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);

			var routeData = new RouteData();
			routeData.Values.Add("controller", "Error");
			routeData.Values.Add("fromAppErrorEvent", true);

			switch (httpException.GetHttpCode())
			{
				case 404:
					routeData.Values.Add("action", "Error404");
					break;

				default:
					routeData.Values.Add("action", "Error500");
					break;
			}

			Server.ClearError();

			IController controller = new ErrorController();
			controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
			Response.End();
		}
	}
}
