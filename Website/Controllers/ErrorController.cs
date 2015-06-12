using System.Web.Mvc;

namespace VirtoCommerce.Controllers
{
	public class ErrorController : Controller
	{
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