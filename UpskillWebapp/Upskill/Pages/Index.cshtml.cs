using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upskill.Models;
using Upskill.Data;
using Microsoft.EntityFrameworkCore;

namespace Upskill.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly UpskillContext _context;

		public IndexModel(ILogger<IndexModel> logger, UpskillContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IList<Job> Jobs { get; set; }
		public IList<Customer> Customers { get; set; }

		public async Task OnGetAsync()
		{
			IQueryable<Job> jobsQuery = from j in _context.Jobs
										select j;
			jobsQuery = jobsQuery.OrderByDescending(j => j.CreationTime)
				.Take(5);

			Jobs = await jobsQuery
				.Include(j => j.Customer)
				.AsNoTracking()
				.ToListAsync();

			IQueryable<Customer> customersQuery = from c in _context.Customers
												  select c;
			customersQuery = customersQuery.OrderByDescending(c => c.Jobs.Count())
				.Take(5);

			Customers = await customersQuery
				.AsNoTracking()
				.ToListAsync();
		}
	}
}
