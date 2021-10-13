using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskProject.Migrations
{
    public partial class AddsUserIDFieldToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Tasks");
        }
    }
}
