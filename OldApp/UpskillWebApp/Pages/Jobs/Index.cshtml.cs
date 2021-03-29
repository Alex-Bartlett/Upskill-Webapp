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
    public class IndexModel : PageModel
    {
        private readonly UpskillWebApp.Data.JobsContext _context;

        public IndexModel(UpskillWebApp.Data.JobsContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Job.ToListAsync();
        }
    }
}
