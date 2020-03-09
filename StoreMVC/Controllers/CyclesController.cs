using StoreMVC.Models;
using StoreMVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StoreMVC.Controllers
{
	public class CyclesController : Controller
	{
		public ViewResult Index()
		{
			var cycles = GetCycles();

			return View(cycles);
		}

		private IEnumerable<Cycle> GetCycles()
		{
			return new List<Cycle>
			{
				new Cycle { Id = 1, Name = "Mountain Bike" },
				new Cycle { Id = 2, Name = "Road Bike" }
			};
		}

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