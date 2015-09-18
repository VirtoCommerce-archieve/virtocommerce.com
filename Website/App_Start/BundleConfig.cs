using System.Web;
using System.Web.Optimization;

namespace VirtoCommerce
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/defaultJS").Include(
					  "~/Scripts/js/main.js",
					  "~/Scripts/js/modernizr.js",
					  "~/Scripts/jquery-{version}.js",
					  "~/Scripts/jquery.validate.js",
					  "~/Scripts/jquery.validate.unobtrusive.js"));

			bundles.Add(new StyleBundle("~/defaultCSS").
				Include("~/Content/css/reset.css", new CssRewriteUrlTransform()).
				Include("~/Content/css/fonts.css", new CssRewriteUrlTransform()).
				Include("~/Content/css/main.css", new CssRewriteUrlTransform()).
				Include("~/Content/css/flags.css", new CssRewriteUrlTransform()).
				Include("~/Content/css/responsive.css", new CssRewriteUrlTransform()));

			// Set EnableOptimizations to false for debugging. For more information,
			// visit http://go.microsoft.com/fwlink/?LinkId=301862
			BundleTable.EnableOptimizations = true;
		}
	}
}
