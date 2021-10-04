using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.StaffJobs
{
    public class EditModel : StaffNamePageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public EditModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StaffJob StaffJob { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            StaffJob = await _context.StaffJobs
                .Include(s => s.StaffMember).FirstOrDefaultAsync(m => m.ID == id);

            if (StaffJob == null)
            {
                return NotFound();
            }
            PopulateStaffDropDownList(_context, StaffJob.StaffMemberID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var taskToUpdate = await _context.StaffJobs.FindAsync(id);

            if (taskToUpdate is null)
			{
                return NotFound();
			}

            if (await TryUpdateModelAsync<StaffJob>(taskToUpdate,"staffjob",
                t => t.ID,
                t => t.StaffMemberID,
                t => t.Date,
                t => t.DaysWorked,
                t => t.HoursWorked,
                t => t.Materials,
                t => t.Notes,
                t => t.CreationTime
				))
			{
                //Update creationTime of related Job
                var job = await _context.Jobs.FindAsync(taskToUpdate.JobID);
                job.CreationTime = DateTime.Now;

                await _context.SaveChangesAsync();
                return Redirect($"/Jobs/Details?id={taskToUpdate.JobID}"); //Return to the job's page.
            }

            return Page();
        }

        private bool StaffJobExists(int id)
        {
            return _context.StaffJobs.Any(e => e.ID == id);
        }
    }
}
