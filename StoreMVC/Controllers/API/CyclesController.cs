using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using StoreMVC.Models;

namespace StoreMVC.Controllers.API
{
    public class CyclesController : ApiController
    {
        private readonly MyDBContext _context;

        public CyclesController()
        {
            _context = new MyDBContext();
        }

        [HttpGet]
        public IEnumerable<Cycle> GetCycles()
        {
            return _context.Cycles.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetCycle(int id)
        {
            var cycle = _context.Cycles.SingleOrDefault(x => x.Id == id);

            if (cycle == null)
                return NotFound();

            return Ok(cycle);
        }

        [HttpPost]
        public IHttpActionResult CreateCycle(Cycle cycle)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Cycles.Add(cycle);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/"+cycle.Id), cycle);
        }

        [HttpPut]
        public void UpdateCycle(int id, Cycle cycle)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cycleInDB = _context.Cycles.SingleOrDefault(x => x.Id == id);
            if (cycleInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            cycleInDB.Name = cycle.Name;
            cycleInDB.NumberInStock = cycle.NumberInStock;
            cycleInDB.ReleaseDate = cycle.ReleaseDate;
            cycleInDB.BikeType = cycle.BikeType;
            cycleInDB.DateAdded = cycle.DateAdded;

            _context.SaveChanges();
        }

        //Delete /api/cycle/1
        [HttpDelete]
        public void DeleteCycle(int id)
        {
            var cycle = _context.Cycles.SingleOrDefault(c => c.Id == id);
            if (cycle == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Cycles.Remove(cycle);
            _context.SaveChanges();
        }
    }
}