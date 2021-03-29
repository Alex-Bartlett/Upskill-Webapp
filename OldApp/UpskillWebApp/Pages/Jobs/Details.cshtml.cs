using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UpskillWebApp.Data;
using UpskillWebApp.Models;

namespace UpskillWebApp.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly UpskillWebApp.Data.JobsContext _context;

        public DetailsModel(UpskillWebApp.Data.JobsContext context)
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

            Job = await _context.Job.FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
