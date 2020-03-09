using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{	
	public class Customer
	{
		public int ID { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubscribedToNewsLetter { get; set; }
		public MemberShipType MemberShipType { get; set; }
		public byte MemberShipTypeId { get; set; }		
		public DateTime? Birthdate { get; set; }
	}
}