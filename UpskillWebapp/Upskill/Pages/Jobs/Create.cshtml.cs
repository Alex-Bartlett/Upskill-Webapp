using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Upskill.Data;
using Upskill.Models;
using Microsoft.EntityFrameworkCore;

namespace Upskill.Pages.Jobs
{
    public class CreateModel : CustomerNamePageModel //This inherits from customerNamePageModel, which uses PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public CreateModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? customer)
        {
            if (customer is not null)
            {
                PopulateCustomerDropDownList(_context, customer);
            }
			else
			{
                PopulateCustomerDropDownList(_context);
			}
            
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; }

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
        {
            var emptyJob = new Job();

            //Auto-generate a job reference if one hasn't been supplied
            if (await TryUpdateModelAsync<Job>(emptyJob, "job",
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
            s => s.SignificantPurchases,
            s => s.Notes,
            s => s.CreationTime))
            {
                _context.Jobs.Add(emptyJob);
                await _context.SaveChangesAsync();

                //Generate a job reference if one is not supplied
                if (String.IsNullOrEmpty(Job.JobReference))
				{
                    await UpdateJobReference();
				}

                return RedirectToPage("./Index");
            }           
            

            PopulateCustomerDropDownList(_context, emptyJob.CustomerID);
            return Page();
        }


        /// <summary>
        /// Updates the job reference of the job in scope
        /// </summary>
        async Task UpdateJobReference()
		{
            var job = _context.Jobs.Where(j => j.CustomerID == Job.CustomerID)
                                                .OrderByDescending(j => j.ID)
                                                .First();

            job.JobReference = GenerateJobReference(job, _context);

            await _context.SaveChangesAsync();

		}
    }
}
