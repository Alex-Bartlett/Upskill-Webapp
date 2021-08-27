using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.StaffJobs
{
    public class DetailsModel : StaffNamePageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public DetailsModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        public StaffJob StaffJob { get; set; }
        [BindProperty]
		public string ReturnURL { get; set; }
		public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReturnURL = Request.Headers["Referer"].ToString();

            StaffJob = await _context.StaffJobs
                .Include(s => s.StaffMember).FirstOrDefaultAsync(m => m.ID == id);

            if (StaffJob == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
