using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UpskillWebApp.Models;

namespace UpskillWebApp.Data
{
	public class JobContext : DbContext
	{
		public JobContext(DbContextOptions<JobContext> options) : base(options)
		{
		}

		public DbSet<Job> Job { get; set; }

	}
}
