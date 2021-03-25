using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UpskillsWebApplication.Models
{
    public partial class UpskillsContext : DbContext
    {
        public UpskillsContext()
        {
        }

        public UpskillsContext(DbContextOptions<UpskillsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Upskills;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Table");

                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNumber)
                    .HasColumnName("home_number")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNumber)
                    .HasColumnName("house_number")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobile_number")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__jobs__6E32B6A55E22BC8F");

                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateDue)
                    .HasColumnName("date_due")
                    .HasColumnType("date");

                entity.Property(e => e.DateFinished)
                    .HasColumnName("date_finished")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasColumnType("date");

                entity.Property(e => e.DaysWorked)
                    .HasColumnName("days_worked")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.HoursWorked)
                    .HasColumnName("hours_worked")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.InvoicedAmount)
                    .HasColumnName("invoiced_amount")
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JobReference)
                    .HasColumnName("job_reference")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QuotedAmount)
                    .HasColumnName("quoted_amount")
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Staff)
                    .HasColumnName("staff")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_jobs_customers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_jobs_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
