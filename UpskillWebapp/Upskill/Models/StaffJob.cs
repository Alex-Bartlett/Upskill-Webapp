using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Upskill.Models
{
	public class StaffJob
	{
		public int ID { get; set; }
		public int JobID { get; set; }
		public int StaffMemberID { get; set; }
		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		public DateTime? Date { get; set; }
		[Display(Name = "Hours Worked")]
		public int? HoursWorked { get; set; }
		[Display(Name = "Days Worked")]
		public int? DaysWorked { get; set; }
		public string Materials { get; set; }
		public string Notes { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CreationTime { get; set; }

		[Display(Name = "Staff Member")]
		public StaffMember StaffMember { get; set; }
	}
}
