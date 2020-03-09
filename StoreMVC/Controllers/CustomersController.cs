using StoreMVC.Models;
using StoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace StoreMVC.Controllers
{
	public class CustomersController : Controller
	{
		private MyDBContext _context;

		public CustomersController()
		{
			_context = new MyDBContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();	
		}

		public ViewResult Index()
		{
			//Include (System.Data.Entity) : Eager Loading. Since, Entity frmwork only loads the Customer model data.
			var customer = _context.Customers.Include(c => c.MemberShipType).ToList();

			return View(customer);
		}

		// GET: Customers
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c =>c.MemberShipType).SingleOrDefault(c => c.ID == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

	}
}