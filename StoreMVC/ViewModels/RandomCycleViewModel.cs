using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreMVC.ViewModels
{
	public class RandomCycleViewModel
	{
		public Customer Customer { get; set; }
		public Cycle Cycle { get; set; }
		public List<Cycle> Cycles { get; set; }
		public List<Customer> Customers { get; set; }
	}
}