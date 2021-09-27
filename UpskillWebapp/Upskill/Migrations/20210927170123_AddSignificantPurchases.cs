using Microsoft.EntityFrameworkCore.Migrations;

namespace Upskill.Migrations
{
    public partial class AddSignificantPurchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SignificantPurchases",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignificantPurchases",
                table: "Job");
        }
    }
}
