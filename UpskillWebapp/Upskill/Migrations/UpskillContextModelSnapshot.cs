﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Upskill.Data;

namespace Upskill.Data.Migrations
{
    [DbContext(typeof(UpskillContext))]
    partial class UpskillContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Upskill.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Upskill.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("DaysWorked")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<string>("JobReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignificantPurchases")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Upskill.Models.StaffJob", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DaysWorked")
                        .HasColumnType("int");

                    b.Property<int?>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<string>("Materials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffMemberID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JobID");

                    b.HasIndex("StaffMemberID");

                    b.ToTable("StaffJob");
                });

            modelBuilder.Entity("Upskill.Models.StaffMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StaffMember");
                });

            modelBuilder.Entity("Upskill.Models.Job", b =>
                {
                    b.HasOne("Upskill.Models.Customer", "Customer")
                        .WithMany("Jobs")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Upskill.Models.StaffJob", b =>
                {
                    b.HasOne("Upskill.Models.Job", null)
                        .WithMany("StaffJobs")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Upskill.Models.StaffMember", "StaffMember")
                        .WithMany("StaffJobs")
                        .HasForeignKey("StaffMemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("Upskill.Models.Customer", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Upskill.Models.Job", b =>
                {
                    b.Navigation("StaffJobs");
                });

            modelBuilder.Entity("Upskill.Models.StaffMember", b =>
                {
                    b.Navigation("StaffJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
