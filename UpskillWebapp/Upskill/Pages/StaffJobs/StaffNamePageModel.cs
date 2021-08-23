using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Upskill.Models;
using Microsoft.AspNetCore.Mvc;

namespace Upskill.Pages.StaffJobs
{
	public class StaffNamePageModel : PageModel
	{
		public SelectList StaffNameSL { get; set; }

		public void PopulateStaffDropDownList(UpskillContext _context,
			object selectedStaff = null)
		{
			var staffQuery = from s in _context.Staff
								 orderby s.Surname
								 select s;

			StaffNameSL = new SelectList(staffQuery.AsNoTracking(), "ID", "FullName", selectedStaff);
		}

		public async Task<IActionResult> DeleteStaffJob(UpskillContext _context, int id)
		{
			StaffJob staffJob = await _context.StaffJobs.FindAsync(id);
			if (staffJob is not null)
			{
				_context.StaffJobs.Remove(staffJob);
				await _context.SaveChangesAsync();
			}
			return Page();
			
		}
    }
}
