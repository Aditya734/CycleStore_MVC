using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
	public class Cycle
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }
		
		public BikeType BikeType { get; set; }

		[Required]
		[Display(Name = "Bicycle Type")]
		public byte BikeTypeId { get; set; }

		public DateTime DateAdded { get; set; }
		
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Range(1,500)]
		[Display(Name= "Numbers in Stock")]
		public byte NumberInStock { get; set; }
	}
}