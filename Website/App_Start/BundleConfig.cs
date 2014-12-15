using System.Web;
using System.Web.Optimization;

namespace VirtoCommerce
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			//bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
			//			"~/Scripts/jquery-{version}.js"));

			//bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
			//			"~/Scripts/jquery.validate*"));

			//// Use the development version of Modernizr to develop with and learn from. Then, when you're
			//// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
			//			"~/Scripts/modernizr-*"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
			//		  "~/Scripts/bootstrap.js",
			//		  "~/Scripts/respond.js"));

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
