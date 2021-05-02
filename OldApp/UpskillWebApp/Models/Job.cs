using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpskillWebApp.Models
{
	public class Job
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Job_reference { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date_start { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date_finished { get; set; }


		public decimal Quoted_amount { get; set; }
		public decimal Invoiced_amount { get; set; }
		public decimal Hours_worked { get; set; }
		public decimal Days_worked { get; set; }
		public int CustomerID { get; set; }
		public Customer Customer { get; set; }
		public string Status { get; set; }
		[DataType(DataType.Date)]
		public DateTime Date_due { get; set; }
		public string Address { get; set; }
		public string Postcode { get; set; }
		public string Notes { get; set; }

		public ICollection<Staff> Staffs { get; set; }

	}
}
