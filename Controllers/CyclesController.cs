using StoreMVC.Models;
using System.Web.Mvc;

namespace StoreMVC.Controllers
{
	public class CyclesController : Controller
	{
		// GET: Cycles/Random
		public ActionResult Random()
		{
			var cycle = new Cycle() { Name = "Mountain Bike" };
			//return View(cycle);
			return RedirectToAction("Index", "Home");
		}
		//^:Regex string opening, $: Regex string closing
		[Route("Cycles/Release/{Year:regex(^\\d{4}$)}/{Month:regex(^\\d{2}$):range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content($"{year}/{month}");			
		}

	}
}