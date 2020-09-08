using StoreMVC.Models;
using StoreMVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System;

namespace StoreMVC.Controllers
{
	public class CyclesController : Controller
	{
		private MyDBContext _myContext;

		public CyclesController()
		{
			_myContext = new MyDBContext();
		}

		protected override void Dispose(bool disposing)
		{
			_myContext.Dispose();
		}

		public ActionResult New()
		{
			var cycleType = _myContext.BikeTypes.ToList();
			var viewModel = new CycleFormViewModel
			{				
				BikeTypes = cycleType
			};

			return View("CycleForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var cycle = _myContext.Cycles.SingleOrDefault(c => c.Id == id);

			if (cycle == null)
				return HttpNotFound();

			var viewModel = new CycleFormViewModel(cycle)
			{
				BikeTypes = _myContext.BikeTypes.ToList()
			};

			return View("CycleForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Cycle cycle)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CycleFormViewModel(cycle)
				{
					BikeTypes = _myContext.BikeTypes.ToList()
				};
				return View("CycleForm", viewModel);
			}
			if (cycle.Id == 0)
			{
				cycle.DateAdded = DateTime.Now;
				_myContext.Cycles.Add(cycle);
			}				
			else
			{
				var cycleInDB = _myContext.Cycles.Single(c => c.Id == cycle.Id);

				cycleInDB.Name = cycle.Name;
				cycleInDB.ReleaseDate = cycle.ReleaseDate;
				cycleInDB.BikeTypeId = cycle.BikeTypeId;
				cycleInDB.NumberInStock = cycle.NumberInStock;				
			}

			_myContext.SaveChanges();

			return RedirectToAction("Index", "Cycles");
		}

		public ViewResult Index()
		{
			var cycles = _myContext.Cycles.Include(c => c.BikeType).ToList();

			return View(cycles);
		}

		// GET: Cycles/Random
		public ActionResult Details(int id)
		{
			var cycle = _myContext.Cycles.Include(c => c.BikeType).SingleOrDefault(c => c.Id == id);

			if (cycle == null)
			{
				return HttpNotFound();
			}

			return View(cycle);
		}

		//^:Regex string opening, $: Regex string closing
		[Route("Cycles/Release/{Year:regex(^\\d{4}$)}/{Month:regex(^\\d{2}$):range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content($"{year}/{month}");			
		}

	}
}