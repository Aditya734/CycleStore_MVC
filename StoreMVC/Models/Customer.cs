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

		[Required(ErrorMessage ="Please enter user name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsLetter { get; set; }
		
		public MemberShipType MemberShipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MemberShipTypeId { get; set; }	
		
		[Display(Name="Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}