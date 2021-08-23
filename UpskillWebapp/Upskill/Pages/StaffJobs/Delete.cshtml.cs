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
    public class DeleteModel : PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public DeleteModel(Upskill.Data.UpskillContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffJob = await _context.StaffJobs.FindAsync(id);

            if (StaffJob != null)
            {
                _context.StaffJobs.Remove(StaffJob);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
