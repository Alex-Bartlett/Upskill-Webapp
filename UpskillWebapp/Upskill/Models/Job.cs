using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Upskill.Models
{
	public class Job
	{
		public enum statusType
		{
			Pending,
			Started,
			Completed,
			Invoiced
		}

		public int ID { get; set; }
		[Display(Name = "Reference")]
		public string JobReference { get; set; }
		[Required]
		public int CustomerID { get; set; }
		[Required]
		public string Address { get; set; }
		public string Town { get; set; }
		public string Postcode { get; set; }
		[Required]
		public statusType Status { get; set; }
		[Display(Name = "Hours Worked")]
		public int? HoursWorked { get; set; }
		[Display(Name = "Individual Days Worked")]
		public int? DaysWorked { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Due Date")]
		public DateTime? DueDate { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date Started")]
		public DateTime? StartDate { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date Finished")]
		public DateTime? FinishedDate { get; set; }
		public string Notes { get; set; }
		public Customer Customer { get; set; }
		public ICollection<StaffJob> StaffJobs { get; set; }
	}
}
