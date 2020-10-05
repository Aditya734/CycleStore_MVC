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

		public ViewResult New()
		{
			var membershipType = _context.MemberShipTypes.ToList();
			var viewModel = new CustomerFormViewModel
			{
				 Customer = new Customer(),
				MemberShipTypes = membershipType
			};

			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					 MemberShipTypes = _context.MemberShipTypes.ToList(),
					 Customer = customer
				};
				return View("CustomerForm", viewModel);
			}

			if(customer.ID == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);

				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
				customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}

		// GET: Customers
		public ViewResult Index()
		{
			//Include (System.Data.Entity) : Eager Loading. Since, Entity frmwork only loads the Customer model data.
			//var customer = _context.Customers.Include(c => c.MemberShipType).ToList();

			return View();
		}

		// GET: Customers/Details/{id}
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c =>c.MemberShipType).SingleOrDefault(c => c.ID == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

			if (customer == null)
			{
				return HttpNotFound();
			}

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MemberShipTypes = _context.MemberShipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}

	}
}