﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.StaffJobs
{
    public class EditModel : StaffNamePageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public EditModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            PopulateStaffDropDownList(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateStaffDropDownList(_context);
                return Page();
            }

            _context.Attach(StaffJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffJobExists(StaffJob.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage(ReturnURL);
        }

        private bool StaffJobExists(int id)
        {
            return _context.StaffJobs.Any(e => e.ID == id);
        }
    }
}