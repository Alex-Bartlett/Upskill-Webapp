using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Upskill.Models
{
	public class StaffMember
	{
		public int ID { get; set; }
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		public string Surname { get; set; }

		public ICollection<StaffJob> StaffJobs { get; set; }
	}
}
