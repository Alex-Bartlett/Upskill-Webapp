using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public CreateModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(bool? redirectToJob)
        {
            RedirectToJob = redirectToJob;
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
		public bool? RedirectToJob { get; set; }

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            //If user used 'new customer' button on job page then route back to that page with customer.
            if (RedirectToJob.HasValue)
            {
                return Redirect("/Jobs/Create?customer=" + Customer.ID);
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}
