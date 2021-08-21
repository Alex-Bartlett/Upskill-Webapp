using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upskill.Models
{
	public class AssignedStaffData
	{
		public int StaffJobID { get; set; }
		public string StaffMemberName { get; set; }
		public int? HoursWorked { get; set; }
		public string Notes { get; set; }
	}
}
