using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
	public class MyDBContext : DbContext
	{
		public MyDBContext()
		{

		}
		public DbSet<Customer> Customers { get; set; } // My domain models
		public DbSet<Cycle> Cycles { get; set; }// My domain models
	}
}