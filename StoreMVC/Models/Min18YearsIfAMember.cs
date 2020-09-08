using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreMVC.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;

			if (customer.MemberShipTypeId==MemberShipType.Unknown 
				|| customer.MemberShipTypeId== MemberShipType.PayAsYouGo)
			{
				return ValidationResult.Success;
			}

			if (customer.Birthdate == null)
			{
				return new ValidationResult("Birthdat is required for selected Membership Type.");
			}

			var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

			return (age > 18) 
				? ValidationResult.Success 
				: new ValidationResult("Age must be gretaer than 18 to subscibe to selected Membership Type.");


		}
	}
}