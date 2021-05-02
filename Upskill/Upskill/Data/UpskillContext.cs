using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Upskill.Models;

namespace Upskill.Data
{
	public class UpskillContext : DbContext
	{
		public UpskillContext(DbContextOptions<UpskillContext> options)
			: base(options)
		{
		}

		public DbSet<Job> Jobs { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<StaffMember> Staff { get; set; }
		public DbSet<StaffJob> StaffJobs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Establish relationships between the tables

			//Create a one to many relationship between Customers and Jobs
			modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
			//.HasMany(c => c.Jobs)
			//.WithOne(j => j.Customer);
			//Create a one to many relationship between Jobs and StaffJobs
			modelBuilder.Entity<Job>().ToTable(nameof(Job));
			//.HasMany(j => j.StaffJobs)
			//.WithOne(sj => sj.Job);
			//Create a many to one relationship between StaffJobs and StaffMembers
			modelBuilder.Entity<StaffJob>().ToTable(nameof(StaffJob));
				//.HasOne(sj => sj.StaffMember)
				//.WithMany(sm => sm.StaffJobs);
			//No necessary relationships to be established
			modelBuilder.Entity<StaffMember>().ToTable(nameof(StaffMember));
		}
	}
}
