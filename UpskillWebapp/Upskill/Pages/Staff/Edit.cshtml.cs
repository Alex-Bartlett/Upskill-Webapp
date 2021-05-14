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

namespace Upskill.Pages.Staff
{
    public class EditModel : PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public EditModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffMember = await _context.Staff.FirstOrDefaultAsync(m => m.ID == id);

            if (StaffMember == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StaffMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffMemberExists(StaffMember.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StaffMemberExists(int id)
        {
            return _context.Staff.Any(e => e.ID == id);
        }
    }
}
