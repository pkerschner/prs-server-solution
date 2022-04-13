using Microsoft.EntityFrameworkCore.Migrations;

namespace prs_server_project.Migrations
{
    public partial class Correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DelliveryMode",
                table: "Requests",
                newName: "DeliveryMode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryMode",
                table: "Requests",
                newName: "DelliveryMode");
        }
    }
}
