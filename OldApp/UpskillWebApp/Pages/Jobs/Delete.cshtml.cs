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
    public class DeleteModel : PageModel
    {
        private readonly UpskillWebApp.Data.JobsContext _context;

        public DeleteModel(UpskillWebApp.Data.JobsContext context)
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

            Job = await _context.Job.FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job.FindAsync(id);

            if (Job != null)
            {
                _context.Job.Remove(Job);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
