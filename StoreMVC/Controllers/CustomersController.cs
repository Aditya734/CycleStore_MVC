using StoreMVC.Models;
using StoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreMVC.Controllers
{
	public class CustomersController : Controller
	{		
		// GET: Customers
		[Route("Customers/Details/{Id?}")]
		public ActionResult Details(int? id)
		{
			RandomCycleViewModel viewModel;
			List<Customer> customers = new List<Customer>
			{
				new Customer{ Name = "Ram", ID = 1},
				new Customer{ Name = "Shyam", ID = 2}
			};
			if (customers.Exists(i=>i.ID==id))
			{
				viewModel = new RandomCycleViewModel
				{
					Customers = null,
					Customer = customers.Find(i=>i.ID==id)
				};
			}
			else if(id == null)
			{
				viewModel = new RandomCycleViewModel
				{
					Customer = null,
					Customers = customers
				};
			}
			else
			{
				return HttpNotFound();
			}
			return View(viewModel);
		}

	}
}