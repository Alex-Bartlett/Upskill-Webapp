﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upskill.Migrations
{
    public partial class StaffJobImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StaffJob",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Materials",
                table: "StaffJob",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "StaffJob");

            migrationBuilder.DropColumn(
                name: "Materials",
                table: "StaffJob");
        }
    }
}
