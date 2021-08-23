using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Upskill.Models;
using Upskill.Pages.StaffJobs;

namespace Upskill.Pages.Jobs
{
    public class DetailsModel : StaffNamePageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public DetailsModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        public Job Job { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs
                .Include(j => j.StaffJobs)
                    .ThenInclude(sj => sj.StaffMember)
                .Include(j => j.Customer).FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id, int? jobId)
		{
            if(id.HasValue)
			{
                await DeleteStaffJob(_context, id.Value);
			}
            return Redirect($"./Details?id={jobId.GetValueOrDefault()}");
		}
    }
}
