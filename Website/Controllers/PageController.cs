using System;
using System.Web;
using VirtoCommerce.Helpers;

namespace MarketplaceWeb.Controllers
{
    using System.Web.Hosting;
    using System.Web.Mvc;
    using VirtoCommerce.Helpers.Models;
    using VirtoCommerce.Publishing;
    using VirtoCommerce.Publishing.Engines;


	//[RoutePrefix("")]
	public class PageController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

        [Route("assets/{*assetId}")]
        public ActionResult Asset(string assetId)
        {
            var virtualPath = String.Format("~/App_Data/vc-contents/{0}", assetId);
            return new DownloadResult(virtualPath);
        }

		//[Route("{pagename}")]
		public ActionResult DisplayPage(string pageName)
		{
			SetMeta();

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
				{
					SetSpecialMeta(item);
					return this.View(item.Layout, item);
				}
				else
				{
                    throw new HttpException(404, "Page doesn't exist.");
				}
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

		private void SetSpecialMeta(ContentItem item)
		{
			ViewBag.Title = item.Title;
			ViewBag.Canonical = item.Canonical;
			ViewBag.Description = item.MetaDescription;

			ViewBag.OgImage = item.OgImage;
			ViewBag.OgTitle = item.OgTitle;
			ViewBag.OgSitename = item.OgSitename;

			ViewBag.TwitterImage = item.TwitterImage;
			ViewBag.TwitterCard = item.TwitterCard;
			ViewBag.TwitterDescription = item.TwitterDescription;
			ViewBag.TwitterTitle = item.TwitterTitle;
			ViewBag.TwitterSite = item.TwitterSite;
		}
	}
}