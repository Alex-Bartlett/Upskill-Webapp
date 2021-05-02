using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UpskillWebApp.Models;

namespace UpskillWebApp.Data
{
    public class JobsContext : DbContext
    {
        public JobsContext (DbContextOptions<JobsContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Staff>().ToTable("Staff");
		}
    }
}
