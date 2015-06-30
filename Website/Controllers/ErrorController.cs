using System.Web.Mvc;
using System.Web.Routing;

namespace VirtoCommerce.Controllers
{
    /// <summary>
    /// http://blog.boriseetgerink.nl/2014/11/10/handling-404s-and-500s-in-aspnet-mvc.html
    /// </summary>
    [HandleError]
	public class ErrorController : Controller
	{
        public ActionResult Index(int code)
        {
            Response.StatusCode = code;
            return RedirectToAction("DisplayPage", "Page", new { pageName = code });
            //return View(code.ToString());
        }

		// GET: Error
		public ActionResult Error404()
		{
			Response.StatusCode = 404;
			return View();
		}

		public ActionResult Error500()
		{
			Response.StatusCode = 500;
			return View();
		}
	}
}