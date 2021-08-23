using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.StaffJobs
{
    public class CreateModel : StaffNamePageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public CreateModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

		public IActionResult OnGet(int? id)
        {
            ReturnURL = Request.Headers["Referer"].ToString();
            if (id.HasValue)
            {
                ID = id.Value;
            }
			else
			{
                return Redirect("/Index");
			}
            PopulateStaffDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public StaffJob StaffJob { get; set; }
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
		public string ReturnURL { get; set; }

		public async Task<IActionResult> OnPostAsync()
        {
            var emptyTask = new StaffJob();

            if (await TryUpdateModelAsync<StaffJob>(
                emptyTask,
                "staffjob",
                t => t.StaffMemberID,
                t => t.DaysWorked,
                t => t.HoursWorked,
                t => t.Notes
				))
			{
                
                emptyTask.JobID = ID;
                _context.StaffJobs.Add(emptyTask);
                await _context.SaveChangesAsync();

                //Return to previous page
                return Redirect(ReturnURL);
			}

            //UPDATE THIS TO RETURN TO JOB
            return Page();
        }
    }
}
