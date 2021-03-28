using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpskillWebApp.Models
{
	public class Staff
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Job_Id { get; set; }
		public decimal Hours_worked { get; set; }
		public decimal Days_worked { get; set; }
		public string Notes { get; set; }
	}
}
