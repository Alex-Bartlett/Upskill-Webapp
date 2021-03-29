using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpskillWebApp.Models
{
	public class Customer
	{
		public int ID { get; set; }
		public string First_name { get; set; }
		public string Surname { get; set; }
		public string House_number { get; set; }
		public string Address { get; set; }
		public string Postcode { get; set; }
	}
}
