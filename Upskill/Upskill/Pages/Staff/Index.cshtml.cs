using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Upskill.Data;
using Upskill.Models;

namespace Upskill.Pages.Staff
{
    public class IndexModel : PageModel
    {
        private readonly Upskill.Data.UpskillContext _context;

        public IndexModel(Upskill.Data.UpskillContext context)
        {
            _context = context;
        }

        public IList<StaffMember> StaffMember { get;set; }

        public async Task OnGetAsync()
        {
            StaffMember = await _context.Staff.ToListAsync();
        }
    }
}
