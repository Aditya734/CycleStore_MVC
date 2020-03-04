using StoreMVC.Models;
using StoreMVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StoreMVC.Controllers
{
	public class CyclesController : Controller
	{
		// GET: Cycles/Random
		public ActionResult Random()
		{
			var cycles = new List<Cycle>
			{
				new Cycle{ Name = "Mountain Bike"},
				new Cycle{ Name = "Road Bike"}
			};

			var viewModel = new RandomCycleViewModel
			{
				Cycles = cycles 
			};

			return View(viewModel);
		}

		//^:Regex string opening, $: Regex string closing
		[Route("Cycles/Release/{Year:regex(^\\d{4}$)}/{Month:regex(^\\d{2}$):range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content($"{year}/{month}");			
		}

	}
}