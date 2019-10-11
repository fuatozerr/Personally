using Microsoft.EntityFrameworkCore.Migrations;

namespace Personally.DataAccess.Migrations
{
    public partial class addingnotecategroyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Categories");
        }
    }
}
