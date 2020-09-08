using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreMVC.ViewModels
{
	public class CycleFormViewModel
	{
		public IEnumerable<BikeType> BikeTypes { get; set; }

		public int? Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Bicycle Type")]
		public byte? BikeTypeId { get; set; }

		[Display(Name = "Release Date")]
		[Required]
		public DateTime? ReleaseDate { get; set; }

		[Range(1, 500)]
		[Display(Name = "Numbers in Stock")]
		[Required]
		public byte? NumberInStock { get; set; }

		public CycleFormViewModel()
		{
			Id = 0;
		}

		public CycleFormViewModel(Cycle cycle)
		{
			Id = cycle.Id;
			Name = cycle.Name;
			BikeTypeId = cycle.BikeTypeId;
			ReleaseDate = cycle.ReleaseDate;
			NumberInStock = cycle.NumberInStock;
		}

		public string Title
		{
			get
			{
				return Id != 0 ? "Edit Cycle" : "New Cycle";
			}
		}
	}
}