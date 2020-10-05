using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using StoreMVC.Models;

namespace StoreMVC.Controllers.API
{
    public class CustomersController : ApiController
    {
        private readonly MyDBContext _context;
        public CustomersController()
        {
            _context = new MyDBContext();
        }

        //GET /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.ID), customer);
        }

        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDB.Name = customer.Name;
            customerInDB.Birthdate = customer.Birthdate;
            customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDB.MemberShipTypeId = customer.MemberShipTypeId;

            _context.SaveChanges();
        }

        //Delete /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
