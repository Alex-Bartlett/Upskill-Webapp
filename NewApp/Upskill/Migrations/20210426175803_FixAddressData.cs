using Microsoft.EntityFrameworkCore.Migrations;

namespace Upskill.Data.Migrations
{
    public partial class FixAddressData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "Customer",
                newName: "Town");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Customer",
                newName: "HouseNumber");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
