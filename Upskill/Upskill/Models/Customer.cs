﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Upskill.Models
{
	public class Customer
	{
		public int ID { get; set; }
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Display(Name = "Surname/Company Name")]
		public string Surname { get; set; }
		public string Address { get; set; }
		public string Town { get; set; }
		public string Postcode { get; set; }

		public ICollection<Job> Jobs { get; set; }

		public string FullName { get
			{
				return string.Format("{0}, {1}", Surname, FirstName);
			} }
	}
}
