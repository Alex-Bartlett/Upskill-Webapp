using Microsoft.EntityFrameworkCore.Migrations;

namespace Upskill.Data.Migrations
{
    public partial class RenameCustomerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Customer",
                newName: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customer",
                newName: "ID");
        }
    }
}
