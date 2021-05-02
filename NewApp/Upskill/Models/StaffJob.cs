using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upskill.Models
{
	public class StaffJob
	{
		public int ID { get; set; }
		public int JobID { get; set; }
		public int StaffID { get; set; }
		public int? HoursWorked { get; set; }
		public int? DaysWorked { get; set; }
		public string Notes { get; set; }

		public Job Job { get; set; }
		public StaffMember StaffMember { get; set; }
	}
}
