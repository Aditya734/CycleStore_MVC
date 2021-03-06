﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StoreMVC.Models;

namespace StoreMVC.Dtos
{
    public class CustomerDto
    {
		public int ID { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsLetter { get; set; }

		public byte MemberShipTypeId { get; set; }

		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }
	}
}