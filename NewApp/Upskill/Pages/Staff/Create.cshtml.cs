using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public CreateModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Staff.Add(StaffMember);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
