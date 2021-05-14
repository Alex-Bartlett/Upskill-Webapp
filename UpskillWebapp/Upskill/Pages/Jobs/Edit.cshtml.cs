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

namespace Upskill.Pages.Jobs
{
    public class EditModel : CustomerNamePageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public EditModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs
                .Include(j => j.Customer).FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
            PopulateCustomerDropDownList(_context, Job.CustomerID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobToUpdate = await _context.Jobs.FindAsync(id);

            if (jobToUpdate is null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Job>(jobToUpdate, "job",
                s => s.ID,
                s => s.JobReference,
                s => s.CustomerID,
                s => s.Address,
                s => s.Town,
                s => s.Postcode,
                s => s.Status,
                s => s.HoursWorked,
                s => s.DaysWorked,
                s => s.DueDate,
                s => s.StartDate,
                s => s.FinishedDate,
                s => s.Notes))
            {
                if (String.IsNullOrEmpty(Job.JobReference))
                {
                    await UpdateJobReference();
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateCustomerDropDownList(_context, jobToUpdate.CustomerID);
            return Page();
        }

        async Task UpdateJobReference()
        {
            var job = _context.Jobs.Where(j => j.ID == Job.ID).First();

            job.JobReference = GenerateJobReference(job, _context);

            await _context.SaveChangesAsync();

        }
    }
}
